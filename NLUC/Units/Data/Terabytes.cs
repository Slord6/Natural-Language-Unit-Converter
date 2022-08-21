using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Terabytes : Unit
    {
        public override Units DerivedUnits => Units.Terabit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "TB",
                    "terabyte",
                    "terabytes"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Gigabytes(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Gigabytes(0).FromRootBaseValue(value / 1000);
        }

        public Terabytes(double value) : base(value)
        {

        }
    }
}
