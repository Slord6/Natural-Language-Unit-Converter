using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Electricity
{
    internal class Amperes : Unit
    {
        public override Units DerivedUnits => Units.Ampere;
        public override Units RootBase => Units.Ampere;

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
                    "A",
                    "amp",
                    "amps",
                    "ampere",
                    "amperes"
                };
            }
        }

        public Amperes(double value) : base(value)
        {
        }
    }
}
