namespace NLUC.Units.Time
{
    internal class GalacticYears : Unit
    {
        public override Units DerivedUnits => Units.GalacticYear;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "galactic years",
                    "galactic year",
                    "gal",
                    "gals",
                    "cosmic years",
                    "cosmic year"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            // 230 million years
            return new Years(Value * 230000000).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            // 230 million years
            return new Years(0).FromRootBaseValue(value / 230000000);
        }

        public GalacticYears(double value) : base(value)
        {

        }
    }
}
