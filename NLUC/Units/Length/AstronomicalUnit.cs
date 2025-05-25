using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Au : Unit
    {
        public override Units DerivedUnits => Units.Mile;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "au",
                    "AU"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value * 149597870700).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Metres(0).FromRootBaseValue(value) / 149597870700;
        }

        public Au(double value) : base(value)
        {

        }
    }
}
