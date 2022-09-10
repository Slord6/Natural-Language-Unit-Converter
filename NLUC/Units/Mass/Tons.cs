namespace NLUC.Units.Mass
{
    internal class Tons : Unit
    {
        public override Units DerivedUnits => Units.Ton;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "tons",
                    "ton"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Kilograms(Value * 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Kilograms(0).FromRootBaseValue(value / 1000);
        }

        public Tons(double value) : base(value)
        {

        }
    }
}
