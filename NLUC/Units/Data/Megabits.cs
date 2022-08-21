using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Megabits : Unit
    {
        public override Units DerivedUnits => Units.Megabit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "Mbit",
                    "Mb",
                    "megabit",
                    "megabits"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilobits(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Kilobits(0).FromRootBaseValue(value / 1000);
        }

        public Megabits(double value) : base(value)
        {

        }
    }
}
