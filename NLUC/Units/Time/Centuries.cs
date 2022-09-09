using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Centuries : Unit
    {
        public override Units DerivedUnits => Units.Century;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "centuries",
                    "century"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Decades(Value * 10).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Decades(0).FromRootBaseValue(value / 10);
        }

        public Centuries(double value) : base(value)
        {

        }
    }
}
