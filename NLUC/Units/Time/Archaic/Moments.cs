namespace NLUC.Units.Time.Archaic
{
    internal class Moments : Unit
    {
        public override Units DerivedUnits => Units.Moment;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "moments",
                    "moment",
                    "momentum"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Minutes(Value * 1.5).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Minutes(0).FromRootBaseValue(value / 1.5);
        }

        public Moments(double value) : base(value)
        {

        }
    }
}
