using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Century : Unit
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
            return new Decade(Value * 10).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Decade(0).FromRootBaseValue(value / 10);
        }

        public Century(double value) : base(value)
        {

        }
    }
}
