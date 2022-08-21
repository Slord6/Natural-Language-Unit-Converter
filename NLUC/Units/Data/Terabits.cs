using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Terabits : Unit
    {
        public override Units DerivedUnits => Units.Terabit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "Tbit",
                    "terabit",
                    "terabits"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Gigabits(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Gigabits(0).FromRootBaseValue(value / 1000);
        }

        public Terabits(double value) : base(value)
        {

        }
    }
}
