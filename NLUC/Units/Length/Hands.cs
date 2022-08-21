using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Hands : Unit
    {
        public override Units DerivedUnits => Units.Hand;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "hh",
                    "hand",
                    "hands"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Inches(Value * 4).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Inches(0).FromRootBaseValue(value) / 4;
        }

        public Hands(double value) : base(value)
        {

        }
    }
}
