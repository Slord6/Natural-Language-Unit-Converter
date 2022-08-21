using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Stone : Unit
    {
        public override Units DerivedUnits => Units.Gram;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "st",
                    "stone"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Pounds(Value * 14).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Pounds(0).FromRootBaseValue(value / 14);
        }

        public Stone(double value) : base(value)
        {

        }
    }
}
