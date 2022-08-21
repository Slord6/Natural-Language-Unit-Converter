using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Temperature
{
    internal class Kelvin : Unit
    {
        public override Units DerivedUnits => Units.Kelvin;
        public override Units RootBase => Units.Kelvin;

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
                    "K",
                    "kelvin"
                };
            }
        }

        public Kelvin(double value) : base(value)
        {
        }
    }
}
