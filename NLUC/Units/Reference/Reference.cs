using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units.Reference
{
    internal class Reference
    {
        /// <summary>
        /// Dictionary of SI units to a measured value of a reference
        /// Eg, a 2000kg elephant wishing to be comparible by mass would have
        /// {Units.Kilogram, new Kilograms(2000))}
        /// </summary>
        protected virtual Dictionary<Units, IUnit> ComparableUnits
        {
            get
            {
                return new Dictionary<Units, IUnit>
                {
                };
            }
        }

        public virtual string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    
                };
            }
        }

        public bool CanCompareTo(IUnit other)
        {
            return CanCompareTo(other.RootBase);
        }

        public bool CanCompareTo(Units units)
        {
            return ComparableUnits.ContainsKey(units);
        }

        public virtual bool TryGetReferenceValue(Units unit, out IUnit? refValue)
        {
            if(!CanCompareTo(unit))
            {
                refValue = null;
                return false;
            }
            else
            {
                refValue = ComparableUnits[unit];
                return true;
            }
        }

        public virtual double InReferenceTo(IUnit unit)
        {
            if(!CanCompareTo(unit))
            {
                return double.NaN;
            }
            IUnit comparisonUnit = ComparableUnits[unit.RootBase];
            return unit.ToSIBase().Value / comparisonUnit.ToSIBase().Value;
        }

        public override string ToString()
        {
            return (Shorthand.Length > 0 && Shorthand[0] != null) ? Shorthand[0] : base.ToString();
        }

        public Reference()
        {

        }
    }
}
