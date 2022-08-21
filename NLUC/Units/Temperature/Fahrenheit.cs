using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Temperature
{
    internal class Fahrenheit : Unit
    {
        public override Units DerivedUnits => Units.Fahrenheit;

        public override Units RootBase => Units.Kelvin;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "°F",
                    "F",
                    "fahrenheit"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kelvin((Value + 459.67) / 1.8);
        }

        public override double FromRootBaseValue(double value)
        {
            return (value * 1.8) - 459.67;
        }

        public Fahrenheit(double value) : base(value)
        {

        }
    }
}
