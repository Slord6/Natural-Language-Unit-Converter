using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Seconds : Unit
    {
        public override Units DerivedUnits => Units.Second;

        public override Units RootBase => Units.Second;

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
                    "s",
                    "second",
                    "seconds",
                    "sec",
                    "secs"
                };
            }
        }


        public Seconds(double value) : base(value)
        {
        }
    }
}
