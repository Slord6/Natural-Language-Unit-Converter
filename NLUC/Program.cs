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

    private static void HandleQuery(string query)
    {
        query = query.Trim();
        if (string.IsNullOrEmpty(query)) return;
        if(query == "?")
        {
            GetAllUnits().ForEach(Console.WriteLine);
            return;
        }

        Regex reg = new Regex(@"((?:\d|\.)*)(?: )?(\S*) in (\S*)(?: ?(?:(?:(?:where)|(?:when)) ((?:\d|\.)*) ?(\S*) ?(?:=|is) ?((?:\d|\.)*) ?(\S*)))?");
        Match match = reg.Match(query);

        double fromValue = double.Parse(match.Groups[1].Value);
        string fromShorthand = match.Groups[2].Value;
        string toShorthand = match.Groups[3].Value;

        IUnit[] possibleFromUnits = GetUnit(fromShorthand);
        IUnit[] possibleToUnits = GetUnit(toShorthand);
        IUnit? fromUnit;
        IUnit? toUnit;

        ResolveToLinkedUnits(possibleFromUnits, possibleToUnits, out fromUnit, out toUnit);

        if(fromUnit == null || toUnit == null)
        {
            Console.WriteLine($"Cannot understand units:");
            if (fromUnit == null) Console.WriteLine(fromShorthand);
            if (toUnit == null) Console.WriteLine(toShorthand);
            return;
        }
        if(!fromUnit.HaveSharedRoot(toUnit))
        {
            Console.WriteLine($"{fromShorthand} and {toShorthand} have no shared root");
            return;
        }

        fromUnit.Value = fromValue;
        IUnit fromBase = fromUnit.ToSIBase();
        double toValueBase = fromBase.Value;
        toUnit.Value = toUnit.FromRootBaseValue(toValueBase);
        Console.WriteLine(toUnit);
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