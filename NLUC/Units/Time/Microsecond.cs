using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Microsecond : Unit
    {
        public override Units DerivedUnits => Units.Microsecond;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "μs",
                    "us",
                    "microsecond",
                    "microseconds"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Millisecond(Value / 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Millisecond(0).FromRootBaseValue(value * 1000);
        }

        public Microsecond(double value) : base(value)
        {

        }
    }
}
