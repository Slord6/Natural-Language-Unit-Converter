using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units
{
    internal interface IUnit
    {
        double Value { get; set; }
        Units DerivedUnits { get; }
        Units RootBase { get; }
        // Eg: s, seconds
        string[] Shorthand { get; }
        bool IsSIBase { get; }
        IUnit ToSIBase();
        double FromRootBaseValue(double value);
        bool HaveSharedRoot(IUnit other);
    }
}
