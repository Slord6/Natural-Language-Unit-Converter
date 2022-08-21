using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class USD : Unit
    {
        public override Units DerivedUnits => Units.USD;
        public override Units RootBase => Units.Cent;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "$",
                    "USD",
                    "dollar",
                    "dollars"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Cents(Value * 100);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 100;
        }

        public USD(double value) : base(value)
        {
        }

        public override string ToString()
        {
            return $"USD${Value}";
        }
    }
}
