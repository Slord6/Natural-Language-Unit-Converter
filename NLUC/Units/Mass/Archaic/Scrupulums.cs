namespace NLUC.Units.Mass.Archaic
{
    internal class Scrupulums : Unit
    {
        public override Units DerivedUnits => Units.Scrupulum;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "scrupulum",
                    "scrupulums",
                    "scripulum",
                    "scripulums",
                    "scriptulum",
                    "scriptulums",
                    "scriplus"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Grams(Value * 1.14).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Grams(0).FromRootBaseValue(value / 1.14);
        }

        public Scrupulums(double value) : base(value)
        {

        }
    }
}
