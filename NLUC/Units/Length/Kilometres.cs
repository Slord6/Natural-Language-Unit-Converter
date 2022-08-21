using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Length
{
    internal class Kilometres : Unit
    {
        public override Units DerivedUnits => Units.Kilometre;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "km",
                    "kilometres",
                    "kilmetre"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value * 1000);
        }

        public override double FromRootBaseValue(double value)
        {
            return value / 1000;
        }

        public Kilometres(double value) : base(value)
        {

        }
    }
}
