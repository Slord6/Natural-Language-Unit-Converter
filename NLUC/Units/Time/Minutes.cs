using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Minutes : Unit
    {
        public override Units DerivedUnits => Units.Minute;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "mins",
                    "min",
                    "minutes",
                    "minute"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Seconds(Value * 60);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 60;
        }

        public Minutes(double value) : base(value)
        {

        }
    }
}
