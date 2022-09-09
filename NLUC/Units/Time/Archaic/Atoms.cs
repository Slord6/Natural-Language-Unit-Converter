namespace NLUC.Units.Time.Archaic
{
    internal class Atoms : Unit
    {
        public override Units DerivedUnits => Units.Atom;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "atoms",
                    "atom"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Moments(Value * 0.0018).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Moments(0).FromRootBaseValue(value / 0.0018);
        }

        public Atoms(double value) : base(value)
        {

        }
    }
}
