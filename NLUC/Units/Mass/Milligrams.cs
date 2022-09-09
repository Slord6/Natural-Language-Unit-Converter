namespace NLUC.Units.Mass
{
    internal class Milligrams : Unit
    {
        public override Units DerivedUnits => Units.Milligram;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "mg",
                    "milligram",
                    "milligrams"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Grams(Value / 1000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Grams(0).FromRootBaseValue(value * 1000);
        }

        public Milligrams(double value) : base(value)
        {

        }
    }
}
