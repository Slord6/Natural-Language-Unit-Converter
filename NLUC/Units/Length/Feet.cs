using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Feet : Unit
    {
        public override Units DerivedUnits => Units.Feet;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "'",
                    "ft",
                    "feet",
                    "foot"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Inches(Value * 12).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Inches(0).FromRootBaseValue(value) / 12;
        }

        public Feet(double value) : base(value)
        {

        }
    }
}
