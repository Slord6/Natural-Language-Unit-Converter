using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLUC.Units
{
    internal class RateUnit
    {
        public IUnit UnitX { get; private set; }
        public IUnit PerY { get; private set; }

        public RateUnit(IUnit unitX, IUnit perY)
        {
            this.UnitX = unitX;
            this.PerY = perY;
        }

        public RateUnit ToSiBase()
        {
            return new RateUnit(UnitX.ToSIBase(), PerY.ToSIBase());
        }

        static int CommonFactor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int LowestCommonMultiple(int a, int b)
        {
            return (a / CommonFactor(a, b)) * b;
        }

        public void Normalise()
        {
            double x = UnitX.Value;
            double y = PerY.Value;
            int increases = 0;
            while(Math.Round(x) - x != 0.0 || Math.Round(y) - y != 0.0000000)
            {
                x *= 10;
                y *= 10;
                increases++;
            }

            int hcf = CommonFactor((int)x, (int)y);
            if (hcf <= 0) return;

            UnitX.Value = x / hcf;
            PerY.Value = y / hcf;

            UnitX = UnitX.ToSIBase();
            PerY = PerY.ToSIBase();
        }

        public bool TryConvertTo(IUnit newUnit, IUnit newPer, out RateUnit? compUnit)
        {
            if(!newUnit.HaveSharedRoot(UnitX) || !newPer.HaveSharedRoot(PerY))
            {
                compUnit = null;
                return false;
            }

            newUnit.Value = newUnit.FromRootBaseValue(UnitX.ToSIBase().Value);
            newPer.Value = newPer.FromRootBaseValue(PerY.ToSIBase().Value);
            compUnit = new RateUnit(newUnit, newPer);
            return true;
        }

        public override string ToString()
        {
            return $"{UnitX.Value/PerY.Value} {UnitX.Shorthand[0]}/{PerY.Shorthand[0]}";
        }
    }
}
