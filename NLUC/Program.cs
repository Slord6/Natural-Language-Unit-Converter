using NLUC.Utils;
using NLUC.Units;
using NLUC.Units.Length;
using NLUC.Units.Time;
using System.Text.RegularExpressions;

public static class Program
{
    public static void Main(string[] args)
    {
        string invalidInputMsg = "Invalid input. Try '3 kg in lbs'";
        if (args.Length == 0)
        {
            while (true)
            {
                Console.Write(">");
                string? query = Console.ReadLine();
                if (query == null) continue;
                try
                {
                    HandleQuery(query);
                }
                catch
                {
                    Console.WriteLine(invalidInputMsg);
                }
            }
        }
        else
        {
            string query = string.Join(" ", args);
            try
            {
                HandleQuery(query);
            }
            catch
            {
                Console.WriteLine(invalidInputMsg);
                Console.WriteLine(query);
            }
        }
    }

    private static List<Unit> GetAllUnits()
    {
        return ReflectiveEnumerator.GetEnumerableOfType<Unit>(new object[] { 0 }).ToList<Unit>();
    }

    private static bool IsValidConversion(IUnit? fromUnit, IUnit? toUnit, string fromShorthand, string toShorthand)
    {
        if (fromUnit == null || toUnit == null)
        {
            Console.WriteLine($"Cannot understand units:");
            if (fromUnit == null) Console.WriteLine(fromShorthand);
            if (toUnit == null) Console.WriteLine(toShorthand);
            return false;
        }
        if (!fromUnit.HaveSharedRoot(toUnit))
        {
            Console.WriteLine($"{fromShorthand} and {toShorthand} have no shared root");
            return false;
        }
        return true;
    }

    private static void SimpleConvert(double fromValue, string fromShorthand, string toShorthand, string toShorthandRemainder)
    {
        IUnit[] possibleFromUnits = GetUnit(fromShorthand);
        IUnit[] possibleToUnits = GetUnit(toShorthand);
        IUnit? fromUnit;
        IUnit? toUnit;

        ResolveToLinkedUnits(possibleFromUnits, possibleToUnits, out fromUnit, out toUnit);

        if (!IsValidConversion(fromUnit, toUnit, fromShorthand, toShorthand)) return;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        fromUnit.Value = fromValue;
        IUnit fromBase = fromUnit.ToSIBase();
        double toValueBase = fromBase.Value;
        toUnit.Value = toUnit.FromRootBaseValue(toValueBase);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

        if (!string.IsNullOrEmpty(toShorthandRemainder))
        {
            // Round down first part of conversion and get left over as remainder
            double main = Math.Floor(toUnit.Value);
            double remainder = toUnit.Value - main;
            IUnit? toRemainderUnit;
            IUnit[] possibleRemainderUnits = GetUnit(toShorthandRemainder);
            // Resolve the remainder units and ensure they're valid
            ResolveToLinkedUnits(possibleFromUnits, possibleRemainderUnits, out fromUnit, out toRemainderUnit);
            if (!IsValidConversion(fromUnit, toRemainderUnit, fromShorthand, toShorthandRemainder)) return;

            // The remainder is currently measured in the same units as main, so use toUnit to convert to SI
            // Then use FromRootBaseValue of remainder to convert from SI into the remainder unit
            toUnit.Value = remainder;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            toRemainderUnit.Value = toRemainderUnit.FromRootBaseValue(toUnit.ToSIBase().Value);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            toUnit.Value = main;
            Console.WriteLine($"{toUnit} {toRemainderUnit}");
        } else {
            Console.WriteLine(toUnit);
        }
    }

    private static void RateConvert(double fromValue, string fromUnit, string fromPer, string toUnit, string toPer)
    {
        IUnit? fromUnitRes;
        IUnit? toUnitRes;
        ResolveToLinkedUnits(GetUnit(fromUnit), GetUnit(toUnit), out fromUnitRes, out toUnitRes);
        if (fromUnitRes == null || toUnitRes == null)
        {
            string unknownUnit = fromUnitRes == null ? fromUnit : toUnit;
            Console.WriteLine("Do not understand unit " + unknownUnit);
            return;
        }
        IUnit? fromPerRes;
        IUnit? toPerRes;
        ResolveToLinkedUnits(GetUnit(fromPer), GetUnit(toPer), out fromPerRes, out toPerRes);
        if (fromPerRes == null || toPerRes== null)
        {
            string unknownUnit = fromPerRes == null ? fromPer : toPer;
            Console.WriteLine("Do not understand unit " + unknownUnit);
            return;
        }


        // VALUES
        fromUnitRes.Value = fromValue;
        fromPerRes.Value = 1;

        RateUnit startRate = new RateUnit(fromUnitRes, fromPerRes);
        RateUnit? conversion;
        if(startRate.TryConvertTo(toUnitRes, toPerRes, out conversion))
        {
            if(conversion == null)
            {
                // can't happen
                return;
            }
            //conversion.Normalise();
            Console.WriteLine(conversion);
        } else
        {
            Console.WriteLine($"Cannot convert from {fromUnit}/{fromPer} to {toUnit}/{toPer}");
        }
    }

    private static void HandleQuery(string query)
    {
        query = query.Trim();
        if (string.IsNullOrEmpty(query)) return;
        if(query == "?")
        {
            GetAllUnits().ForEach(Console.WriteLine);
            return;
        }

        Regex reg = new Regex(@"((?:\d|\.)*)(?: )?(\S*) in (\S*)(?: and (\S*))?(?: ?(?:(?:(?:where)|(?:when)) ((?:\d|\.)*) ?(\S*) ?(?:=|is) ?((?:\d|\.)*) ?(\S*)))?");
        Match match = reg.Match(query);

        double fromValue = double.Parse(match.Groups[1].Value);
        string fromShorthand = match.Groups[2].Value;
        string toShorthand = match.Groups[3].Value;
        string toShorthandRemainder = match.Groups[4].Value;

        if(!fromShorthand.Contains("/") && ! toShorthand.Contains("/"))
        {
            SimpleConvert(fromValue, fromShorthand, toShorthand, toShorthandRemainder);
            return;
        }
        else
        {
            string[] from = fromShorthand.Split("/");
            string[] to = toShorthand.Split("/");
            RateConvert(fromValue, from[0], from[1], to[0], to[1]);
        }
    }

    private static void ResolveToLinkedUnits(IUnit[] possibleFrom, IUnit[] possibleTo, out IUnit? from, out IUnit? to)
    {
        from = possibleFrom.FirstOrDefault();
        to = possibleTo.FirstOrDefault();
        // Break early if either is invalid or there's only one choice
        if ((possibleFrom.Length == 1 && possibleTo.Length == 1) || possibleFrom.Length == 0 || possibleTo.Length == 0) return;

        foreach (IUnit possibleFromObj in possibleFrom)
        {
            foreach (IUnit possibleToObj in possibleTo)
            {
                if(possibleFromObj.HaveSharedRoot(possibleToObj))
                {
                    from = possibleFromObj;
                    to = possibleToObj;
                    return;
                }
            }
        }
    }

    private static IUnit[] GetUnit(string shorthand)
    {
        return GetAllUnits().Where(x => x.Shorthand.Contains(shorthand)).ToArray();
    }
}