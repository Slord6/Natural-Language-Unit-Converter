namespace NLUC.Units.Length.Archaic
{
    internal class Ell : Unit
    {
        public override Units DerivedUnits => Units.Ell;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "ell",
                    "ells",
                    "ell-wand",
                    "ell-wands",
                    "ellwand",
                    "ellwands"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Inches(Value * 18).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Inches(0).FromRootBaseValue(value / 18);
        }

        public Ell(double value) : base(value)
        {

        }
    }
}
