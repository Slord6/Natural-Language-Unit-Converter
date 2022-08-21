using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Kilograms : Unit
    {
        public override Units DerivedUnits => Units.Kilogram;
        public override Units RootBase => Units.Kilogram;

        public override IUnit ToSIBase()
        {
            return this;
        }

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "kg",
                    "kilograms",
                    "kilogram"
                };
            }
        }

        public Kilograms(double value) : base(value)
        {
        }
    }
}
