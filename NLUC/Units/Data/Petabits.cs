using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Petabits : Unit
    {
        public override Units DerivedUnits => Units.Petabit;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "Pbit",
                    "petabit",
                    "petabits"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Terabits(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Terabits(0).FromRootBaseValue(value / 1000);
        }

        public Petabits(double value) : base(value)
        {

        }
    }
}
