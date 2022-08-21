using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Nibbles : Unit
    {
        public override Units DerivedUnits => Units.Nibble;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "nibbles",
                    "nibble",
                    "nybble",
                    "nyble"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Bytes(Value).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Bytes(0).FromRootBaseValue(value);
        }

        public Nibbles(double value) : base(value)
        {

        }
    }
}
