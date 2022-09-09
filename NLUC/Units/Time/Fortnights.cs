namespace NLUC.Units.Time
{
    internal class Fortnights : Unit
    {
        public override Units DerivedUnits => Units.Fortnight;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "fortnights",
                    "fortnight"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Weeks(Value * 2).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Weeks(0).FromRootBaseValue(value / 2);
        }

        public Fortnights(double value) : base(value)
        {

        }
    }
}
