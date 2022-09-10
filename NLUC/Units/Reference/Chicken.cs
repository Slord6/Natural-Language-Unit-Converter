using NLUC.Units.Mass;
using NLUC.Units.Length;
using NLUC.Units.Time;
using NLUC.Units.Temperature;

namespace NLUC.Units.Reference
{
    internal class Chicken : Reference
    {
        protected override Dictionary<Units, IUnit> ComparableUnits
        {
            get
            {
                return new Dictionary<Units, IUnit>
                {
                    {Units.Kilogram, new Kilograms(3)},
                    {Units.Metre, new Centimetres(25)},
                    {Units.Second, new Years(7.5)},
                    {Units.Kelvin, new Fahrenheit(105)}
                };
            }
        }

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "chickens",
                    "chicken"
                };
            }
        }

        public Chicken() : base()
        {

        }
    }
}
