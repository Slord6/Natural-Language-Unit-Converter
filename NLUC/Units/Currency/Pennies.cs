using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class Pennies : Unit
    {
        public override Units DerivedUnits => Units.Penny;

        public override Units RootBase => Units.PoundsSterling;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "p",
                    "pence",
                    "pennies",
                    "penny"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new PoundsSterling(Value / 100);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 100;
        }

        public Pennies(double value) : base(value)
        {

        }
    }
}
