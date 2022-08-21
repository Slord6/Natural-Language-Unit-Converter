using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Kilobytes : Unit
    {
        public override Units DerivedUnits => Units.Kilobyte;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "kB",
                    "KByte",
                    "KBytes",
                    "kilobyte",
                    "kilobytes"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Bytes(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Bytes(0).FromRootBaseValue(value / 1000);
        }

        public Kilobytes(double value) : base(value)
        {

        }
    }
}
