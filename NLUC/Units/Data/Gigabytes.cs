using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Gigabytes : Unit
    {
        public override Units DerivedUnits => Units.Gigabyte;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "GB",
                    "gigabyte",
                    "gigabytes"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Megabytes(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Megabytes(0).FromRootBaseValue(value / 1000);
        }

        public Gigabytes(double value) : base(value)
        {

        }
    }
}
