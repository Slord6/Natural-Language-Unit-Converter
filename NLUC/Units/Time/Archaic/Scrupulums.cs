namespace NLUC.Units.Time.Archaic
{
    internal class Scrupulums : Unit
    {
        public override Units DerivedUnits => Units.Scrupulum;

        public override Units RootBase => Units.Second;

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
            return new Minutes(Value * 2.5).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Minutes(0).FromRootBaseValue(value / 2.5);
        }

        public Scrupulums(double value) : base(value)
        {

        }
    }
}
