using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Grams : Unit
    {
        public override Units DerivedUnits => Units.Gram;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "g",
                    "gram",
                    "grams"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilograms(Value / 1000);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 1000;
        }

        public Grams(double value) : base(value)
        {

        }
    }
}
