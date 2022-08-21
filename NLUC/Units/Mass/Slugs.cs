using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Mass
{
    internal class Slugs : Unit
    {
        public override Units DerivedUnits => Units.Slug;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "slugs",
                    "slug"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilograms(Value / 0.0685);
        }

        public override double FromRootBaseValue(double value)
        {
            return value * 0.0685;
        }

        public Slugs(double value) : base(value)
        {

        }
    }
}
