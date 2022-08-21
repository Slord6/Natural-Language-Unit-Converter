using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Centimetres : Unit
    {
        public override Units DerivedUnits => Units.Centimetre;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "cm",
                    "centimetre",
                    "centimetres",
                    "centimetres",
                    "centimeter"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value / 100);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 100;
        }

        public Centimetres(double value) : base(value)
        {

        }
    }
}
