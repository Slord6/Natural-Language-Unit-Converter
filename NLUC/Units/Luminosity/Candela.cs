using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Luminosity
{
    internal class Candela : Unit
    {
        public override Units DerivedUnits => Units.Candela;
        public override Units RootBase => Units.Candela;

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
                    "cd",
                    "candela"
                };
            }
        }

        public Candela(double value) : base(value)
        {
        }
    }
}
