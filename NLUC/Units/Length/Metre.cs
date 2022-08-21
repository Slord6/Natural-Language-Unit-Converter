using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Metres : Unit
    {
        public override Units DerivedUnits => Units.Metre;
        public override Units RootBase => Units.Metre;

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
                    "m",
                    "metre",
                    "meter",
                    "metres",
                    "meters"
                };
            }
        }

        public Metres(double value) : base(value)
        {
        }
    }
}
