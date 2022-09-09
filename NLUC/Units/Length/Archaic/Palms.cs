namespace NLUC.Units.Length.Archaic
{
    internal class Palms : Unit
    {
        public override Units DerivedUnits => Units.Palm;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "palm",
                    "palms"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Inches(Value * 3).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Inches(0).FromRootBaseValue(value / 3);
        }

        public Palms(double value) : base(value)
        {

        }
    }
}
