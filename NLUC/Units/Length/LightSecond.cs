using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class LightSecond : Unit
    {
        public override Units DerivedUnits => Units.Mile;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "light-second",
                    "light-seconds",
                    "ls"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value * 299792458).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Metres(0).FromRootBaseValue(value) / 299792458;
        }

        public LightSecond(double value) : base(value)
        {

        }
    }
}
