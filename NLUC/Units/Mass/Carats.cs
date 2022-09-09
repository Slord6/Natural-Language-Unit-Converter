namespace NLUC.Units.Mass
{
    internal class Carats : Unit
    {
        public override Units DerivedUnits => Units.Carat;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "ct",
                    "carat",
                    "carats"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Milligrams(Value * 200).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Milligrams(0).FromRootBaseValue(value / 200);
        }

        public Carats(double value) : base(value)
        {

        }
    }
}
