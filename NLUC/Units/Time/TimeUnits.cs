namespace NLUC.Units.Time
{
    internal class TimeUnits : Unit
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
            return new Microseconds(Value * 1024).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Microseconds(0).FromRootBaseValue(value / 1024);
        }

        public TimeUnits(double value) : base(value)
        {

        }
    }
}
