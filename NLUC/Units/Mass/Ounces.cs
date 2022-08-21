using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Ounces : Unit
    {
        public override Units DerivedUnits => Units.Gram;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "oz",
                    "ounce",
                    "ounces"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Pounds(Value / 16).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Pounds(0).FromRootBaseValue(value) * 16;
        }

        public Ounces(double value) : base(value)
        {

        }
    }
}
