using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Luminosity
{
    internal class Lumens : Unit
    {
        public override Units DerivedUnits => Units.Lumen;

        public override Units RootBase => Units.Candela;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "L",
                    "lumen",
                    "lumens"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Candela(Value / 12.57);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 12.57;
        }

        public Lumens(double value) : base(value)
        {

        }
    }
}
