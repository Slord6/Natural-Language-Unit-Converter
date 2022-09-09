using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Decades : Unit
    {
        public override Units DerivedUnits => Units.Decade;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "decades",
                    "decade"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Years(Value * 10).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Years(0).FromRootBaseValue(value / 10);
        }

        public Decades(double value) : base(value)
        {

        }
    }
}
