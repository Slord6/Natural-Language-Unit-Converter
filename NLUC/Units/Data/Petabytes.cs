using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Data
{
    internal class Petabytes : Unit
    {
        public override Units DerivedUnits => Units.Petabyte;

        public override Units RootBase => Units.Bit;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "PB",
                    "petabyte",
                    "petabytes"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Terabytes(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Terabytes(0).FromRootBaseValue(value / 1000);
        }

        public Petabytes(double value) : base(value)
        {

        }
    }
}
