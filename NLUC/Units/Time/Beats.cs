using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Time
{
    internal class Beats : Unit
    {
        public override Units DerivedUnits => Units.Beat;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    ".beats",
                    ".beat",
                    "beat",
                    "beats",
                    "swatch"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Days(Value / 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Days(0).FromRootBaseValue(value * 1000);
        }

        public Beats(double value) : base(value)
        {

        }
    }
}
