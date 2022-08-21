using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Millisecond : Unit
    {
        public override Units DerivedUnits => Units.Millisecond;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "ms",
                    "millisecond",
                    "milliseconds"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Seconds(Value / 1000);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 1000;
        }

        public Millisecond(double value) : base(value)
        {

        }
    }
}
