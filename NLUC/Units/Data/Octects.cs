using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Octets : Unit
    {
        public override Units DerivedUnits => Units.Octect;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "o",
                    "octets",
                    "octet"
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

        public Octets(double value) : base(value)
        {

        }
    }
}
