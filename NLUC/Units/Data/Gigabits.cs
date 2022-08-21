using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Gigabits : Unit
    {
        public override Units DerivedUnits => Units.Gigabit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "Gbit",
                    "Gb",
                    "gigabit"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Megabits(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Megabits(0).FromRootBaseValue(value / 1000);
        }

        public Gigabits(double value) : base(value)
        {

        }
    }
}
