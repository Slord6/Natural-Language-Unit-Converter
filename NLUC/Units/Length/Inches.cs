using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Inches : Unit
    {
        public override Units DerivedUnits => Units.Inch;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "\"",
                    "inches",
                    "inch",
                    "in"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Centimetres(Value * 2.54).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Centimetres(0).FromRootBaseValue(value) / 2.54;
        }

        public Inches(double value) : base(value)
        {

        }
    }
}
