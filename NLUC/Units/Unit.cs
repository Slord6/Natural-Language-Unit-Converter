using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units
{
    internal abstract class Unit : IUnit
    {
        public virtual double Value { get; set; }

        public virtual Units RootBase => throw new NotImplementedException();
        public virtual Units DerivedUnits => throw new NotImplementedException();

        public virtual bool IsSIBase
        {
            get
            {
                return DerivedUnits == RootBase;
            }
        }

        public virtual string[] Shorthand => throw new NotImplementedException();

        public virtual IUnit ToSIBase()
        {
            throw new NotImplementedException();
        }

        public virtual double FromRootBaseValue(double value)
        {
            if(IsSIBase) return value;
            throw new NotImplementedException();
        }

        public virtual bool HaveSharedRoot(IUnit other)
        {
            return other.RootBase == RootBase;
        }

        public Unit(double value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} {Shorthand[0]}";
        }
    }
}
