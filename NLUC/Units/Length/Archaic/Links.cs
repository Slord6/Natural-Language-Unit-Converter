namespace NLUC.Units.Length.Archaic
{
    internal class Links : Unit
    {
        public override Units DerivedUnits => Units.Link;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "links",
                    "link"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Chains(Value / 100).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Chains(0).FromRootBaseValue(value * 100);
        }

        public Links(double value) : base(value)
        {

        }
    }
}
