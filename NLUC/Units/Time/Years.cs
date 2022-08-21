using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Years : Unit
    {
        public override Units DerivedUnits => Units.Year;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "yrs",
                    "yr",
                    "year",
                    "years"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Days(Value * 365).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Days(0).FromRootBaseValue(value / 365);
        }

        public Years(double value) : base(value)
        {

        }
    }
}
