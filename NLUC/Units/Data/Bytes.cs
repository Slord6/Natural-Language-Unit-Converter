using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Bytes : Unit
    {
        public override Units DerivedUnits => Units.Byte;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "b",
                    "bytes",
                    "byte"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Bits(Value * 8);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 8;
        }

        public Bytes(double value) : base(value)
        {

        }
    }
}
