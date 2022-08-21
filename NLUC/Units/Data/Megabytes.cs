using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Megabytes : Unit
    {
        public override Units DerivedUnits => Units.Megabyte;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "MB",
                    "MByte",
                    "MBytes",
                    "megabyte",
                    "megabytes"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilobytes(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Kilobytes(0).FromRootBaseValue(value / 1000);
        }

        public Megabytes(double value) : base(value)
        {

        }
    }
}
