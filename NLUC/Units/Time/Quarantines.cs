namespace NLUC.Units.Time
{
    internal class Quarantines : Unit
    {
        public override Units DerivedUnits => Units.Quarantine;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "quarantines",
                    "quarantine"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Days(Value * 40).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Days(0).FromRootBaseValue(value / 40);
        }

        public Quarantines(double value) : base(value)
        {

        }
    }
}
