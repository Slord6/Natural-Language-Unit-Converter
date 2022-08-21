using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Weeks : Unit
    {
        public override Units DerivedUnits => Units.Week;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "weeks",
                    "week",
                    "wk",
                    "wks"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Days(Value * 7).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Days(0).FromRootBaseValue(value / 7);
        }

        public Weeks(double value) : base(value)
        {

        }
    }
}
