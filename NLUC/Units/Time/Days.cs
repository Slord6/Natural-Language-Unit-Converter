using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Days : Unit
    {
        public override Units DerivedUnits => Units.Day;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "day",
                    "days"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Hours(Value * 24).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Hours(0).FromRootBaseValue(value / 24);
        }

        public Days(double value) : base(value)
        {

        }
    }
}
