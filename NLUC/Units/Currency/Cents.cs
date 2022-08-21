using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class Cents : Unit
    {
        public override Units DerivedUnits => Units.Cent;

        public override Units RootBase => Units.Cent;

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
                    "¢",
                    "c",
                    "cent",
                    "cents"
                };
            }
        }

        public override double FromRootBaseValue(double value)
        {
            return value;
        }

        public Cents(double value) : base(value)
        {

        }
    }
}
