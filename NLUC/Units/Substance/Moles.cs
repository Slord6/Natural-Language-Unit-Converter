using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Substance
{
    internal class Moles : Unit
    {
        public override Units DerivedUnits => Units.Mole;
        public override Units RootBase => Units.Mole;

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
                    "mol",
                    "mole",
                    "moles"
                };
            }
        }

        public Moles(double value) : base(value)
        {
        }
    }
}
