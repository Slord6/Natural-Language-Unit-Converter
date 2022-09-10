using NLUC.Units.Mass;
using NLUC.Units.Length;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLUC.Units.Time;
using NLUC.Units.Temperature;

namespace NLUC.Units.Reference
{
    internal class AfricanElephant : Reference
    {
        protected override Dictionary<Units, IUnit> ComparableUnits
        {
            get
            {
                return new Dictionary<Units, IUnit>
                {
                    {Units.Kilogram, new Kilograms(4500)},
                    {Units.Metre, new Metres(3.2)},
                    {Units.Second, new Years(65)},
                    {Units.Kelvin, new Celsius(36.6)}
                };
            }
        }

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "elephants",
                    "elephant",
                    "african elephants",
                    "african elephant"
                };
            }
        }

        public AfricanElephant() : base()
        {

        }
    }
}
