namespace NLUC.Units.Length.Archaic
{
    internal class Digit : Unit
    {
        public override Units DerivedUnits => Units.Digit;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "digit",
                    "digits"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Inches(Value * 0.75).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Inches(0).FromRootBaseValue(value / 0.75);
        }

        public Digit(double value) : base(value)
        {

        }
    }
}
