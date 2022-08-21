using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Miles : Unit
    {
        public override Units DerivedUnits => Units.Mile;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "mile",
                    "miles",
                    "mi"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Feet(Value * 5280).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Feet(0).FromRootBaseValue(value) / 5280;
        }

        public Miles(double value) : base(value)
        {

        }
    }
}
