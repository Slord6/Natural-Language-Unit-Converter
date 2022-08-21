using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Bits : Unit
    {
        public override Units DerivedUnits => Units.Bit;
        public override Units RootBase => Units.Bit;

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
                    "bits",
                    "bit"
                };
            }
        }

        public Bits(double value) : base(value)
        {
        }
    }
}
