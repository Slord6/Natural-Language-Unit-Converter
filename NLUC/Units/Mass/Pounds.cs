using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Pounds : Unit
    {
        public override Units DerivedUnits => Units.Gram;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "lb",
                    "pound",
                    "pounds"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilograms(Value * 0.45359237);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 0.45359237;
        }

        public Pounds(double value) : base(value)
        {

        }
    }
}
