using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class PoundsSterling : Unit
    {
        public override Units DerivedUnits => Units.PoundSterling;
        public override Units RootBase => Units.PoundSterling;

        public override IUnit ToSIBase()
        {
            return this;
        }

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "£",
                    "pounds",
                    "pound",
                    "GBP"
                };
            }
        }

        public PoundsSterling(double value) : base(value)
        {
        }

        public override string ToString()
        {
            return $"£{Value}";
        }
    }
}
