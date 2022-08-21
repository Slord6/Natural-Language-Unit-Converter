using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Temperature
{
    internal class Celsius : Unit
    {
        public override Units DerivedUnits => Units.Celsius;

        public override Units RootBase => Units.Kelvin;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "°C",
                    "C",
                    "°",
                    "celcius"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kelvin(Value + 273.15);
        }

        public override double FromRootBaseValue(double value)
        {
            return value - 273.15;
        }

        public Celsius (double value) : base(value)
        {

        }
    }
}
