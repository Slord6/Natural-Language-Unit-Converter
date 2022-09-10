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
    internal class EmpireStateBuilding : Reference
    {
        protected override Dictionary<Units, IUnit> ComparableUnits
        {
            get
            {
                return new Dictionary<Units, IUnit>
                {
                    {Units.Kilogram, new Tons(365000)},
                    {Units.Metre, new Metres(443)}
                };
            }
        }

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "empire state buildings",
                    "empire state building"
                };
            }
        }

        public EmpireStateBuilding() : base()
        {

        }
    }
}
