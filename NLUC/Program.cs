using NLUC.Utils;
using NLUC.Units;
using NLUC.Units.Length;
using NLUC.Units.Time;
using System.Text.RegularExpressions;

public static class Program
{
    public static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            while (true)
            {
                Console.Write(">");
                string? query = Console.ReadLine();
                if (query == null) continue;
                HandleQuery(query);
            }
        }
        else
        {
            HandleQuery(string.Join(" ", args));
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
        // (\d*)(?: )?(\S*) in (\S*)(?: ?(?:(?:(?:where)|(?:when)) ((?:\d|.)*) ?(\S*) ?= ?((?:\d|\.)*) ?(\S*)))?
        /*  
        * 15l/s in kg/min where 2l = 1.2kg
        * 15
        * l/s
        * kg/min
        * 2
        * l
        * 1.2
        * kg
        * 
        * 13ms^2 in ft/s
        * 13
        * ms^2
        * ft/s
        * <empty>
        * <empty>
        * <empty>
        * <empty>
         */

        Regex reg = new Regex(@"((?:\d|\.)*)(?: )?(\S*) in (\S*)(?: ?(?:(?:(?:where)|(?:when)) ((?:\d|\.)*) ?(\S*) ?(?:=|is) ?((?:\d|\.)*) ?(\S*)))?");
        Match match = reg.Match(query);
        //foreach (Group group in match.Groups)
        //{
        //    if(group.Value == String.Empty)
        //    {
        //        Console.WriteLine("<empty>");
        //        continue;
        //    }
        //    Console.WriteLine(group.Value);
        //}

        double fromValue = double.Parse(match.Groups[1].Value);
        string fromShorthand = match.Groups[2].Value;
        string toShorthand = match.Groups[3].Value;

        //Console.WriteLine($"{fromValue}{fromShorthand} --> {toShorthand}");

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