namespace NLUC.Units.Length
{
    internal class Yards : Unit
    {
        public override Units DerivedUnits => Units.Yard;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "yd",
                    "yds",
                    "yard",
                    "yards"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value * 0.9144).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Metres(0).FromRootBaseValue(value) / 0.9144;
        }

        public Yards(double value) : base(value)
        {

        }
    }
}
