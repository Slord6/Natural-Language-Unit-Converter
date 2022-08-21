using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class Dime : Unit
    {
        public override Units DerivedUnits => Units.Dime;
        public override Units RootBase => Units.Cent;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "dimes",
                    "dime"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Cents(Value * 10);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 10;
        }

        public Dime(double value) : base(value)
        {
        }
    }
}
