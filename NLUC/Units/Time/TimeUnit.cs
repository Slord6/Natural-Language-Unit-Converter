namespace NLUC.Units.Time
{
    internal class TimeUnit : Unit
    {
        public override Units DerivedUnits => Units.TimeUnit;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "TU",
                    "time unit",
                    "time units"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Microsecond(Value * 1024).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Microsecond(0).FromRootBaseValue(value / 1024);
        }

        public TimeUnit(double value) : base(value)
        {

        }
    }
}
