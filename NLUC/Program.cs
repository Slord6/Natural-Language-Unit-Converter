using NLUC.Utils;
using NLUC.Units;
using NLUC.Units.Length;
using NLUC.Units.Time;
using System.Text.RegularExpressions;
using NLUC.Units.Reference;

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

    private static List<Reference> GetAllReferences()
    {
        return ReflectiveEnumerator.GetEnumerableOfType<Reference>(new object[0]).ToList<Reference>();
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

    private static void SimpleConvert(double fromValue, string fromShorthand, string toShorthand, string toShorthandRemainder = null)
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
    
    
    private static Regex conversionRegex = new Regex(@"((?:\d|\.)*)(?: )?(\S*) in (\S*)(?: and (\S*))?(?: ?(?:(?:(?:where)|(?:when)) ((?:\d|\.)*) ?(\S*) ?(?:=|is) ?((?:\d|\.)*) ?(\S*)))?");
    private static Regex referenceRegex = new Regex(@"(\d+) ?(\w*) (?:(?:as)|(?:ref)) (.*)");
    private static void HandleQuery(string query)
    {
        query = query.Trim();
        if (string.IsNullOrEmpty(query)) return;
        if (query == "?")
        {
            Console.WriteLine("===Units===");
            GetAllUnits().ForEach(Console.WriteLine);
            Console.WriteLine("===References===");
            GetAllReferences().ForEach(Console.WriteLine);
            return;
        }

        if (conversionRegex.IsMatch(query))
        {
            HandleConversionQuery(query);
        }
        else if (referenceRegex.IsMatch(query))
        {
            HandleReferenceQuery(query);
        }
    }

    private static void HandleReferenceQuery(string query)
    {
        Match match = referenceRegex.Match(query);
        string fromValue = match.Groups[1].Value;
        string fromShorthand = match.Groups[2].Value;
        string referenceShorthand = match.Groups[3].Value;

        IUnit[] possibleFromUnits = GetUnit(fromShorthand);

        if(possibleFromUnits.Length == 0)
        {
            Console.WriteLine($"Don't understand '{fromShorthand}' as a unit type");
            return;
        }

        Reference[] references = GetAllReferences().Where(x => x.Shorthand.Contains(referenceShorthand)).ToArray();
        if(references.Length == 0)
        {
            Console.WriteLine($"Unknown reference '{referenceShorthand}'");
            return;
        }

        IUnit? from = null;
        Reference? reference = null;
        ResolveToLinkedUnitReference(possibleFromUnits, references, out from, out reference);
        if(from == null || reference == null)
        {
            Console.WriteLine($"{referenceShorthand} can't be used as a reference for {fromShorthand}");
            return;
        }

        from.Value = double.Parse(fromValue);
        double result = reference.InReferenceTo(from);
        if(double.IsNaN(result))
        {
            Console.WriteLine($"{referenceShorthand} has no appropriate value for {fromShorthand}");
            return;
        }
        Console.WriteLine($"{result} {reference}");
    }

    private static void HandleConversionQuery(string query)
    {
        Match match = conversionRegex.Match(query);

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

    /// <summary>
    /// Given two lists of units, find a pair that have a shared root
    /// If no shared root is found, null is returned for 'from' and 'to'
    /// </summary>
    /// <param name="possibleFrom">Possible values to convert from</param>
    /// <param name="possibleTo">Possible values to convert to</param>
    /// <param name="from">Found from, that shares a root with 'to'</param>
    /// <param name="to">Found to, that shares a root with 'from'</param>
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

    private static void ResolveToLinkedUnitReference(IUnit[] possibleFrom, Reference[] possibleReferences, out IUnit? from, out Reference? reference)
    {
        from = possibleFrom.FirstOrDefault();
        reference = possibleReferences.FirstOrDefault();
        // Break early if either is invalid or there's only one choice
        if ((possibleFrom.Length == 1 && possibleReferences.Length == 1) || possibleFrom.Length == 0 || possibleReferences.Length == 0) return;
        foreach (IUnit possibleFromObj in possibleFrom)
        {
            foreach (Reference possibleReference in possibleReferences)
            {
                if(possibleReference.CanCompareTo(possibleFromObj))
                {
                    from = possibleFromObj;
                    reference = possibleReference;
                    return;
                }
            }
        }
    }

    /// <summary>
    /// From a string representation, find units that are represented by that string
    /// </summary>
    /// <param name="shorthand">String representation of a unit</param>
    /// <returns>Units using that string shorthand</returns>
    private static IUnit[] GetUnit(string shorthand)
    {
        return GetAllUnits().Where(x => x.Shorthand.Contains(shorthand)).ToArray();
    }
}