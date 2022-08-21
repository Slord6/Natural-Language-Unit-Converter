using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Currency
{
    internal class PoundsSterling : Unit
    {
        public override Units DerivedUnits => Units.PoundsSterling;
        public override Units RootBase => Units.PoundsSterling;

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
                    "pound"
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
