using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Hours : Unit
    {
        public override Units DerivedUnits => Units.Hours;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "hrs",
                    "hr",
                    "hour",
                    "hours"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Minutes(Value * 60).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Minutes(0).FromRootBaseValue(value / 60);
        }

        public Hours(double value) : base(value)
        {

        }
    }
}
