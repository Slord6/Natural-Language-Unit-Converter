using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Kilobits : Unit
    {
        public override Units DerivedUnits => Units.Kilobit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "kbit",
                    "kb",
                    "kilobit",
                    "kilobits"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Bits(Value * 1000);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 1000;
        }

        public Kilobits(double value) : base(value)
        {

        }
    }
}
