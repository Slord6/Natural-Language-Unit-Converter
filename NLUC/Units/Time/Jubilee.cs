namespace NLUC.Units.Time
{
    internal class Jubilee : Unit
    {
        public override Units DerivedUnits => Units.Jubilee;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "jubilees",
                    "jubilee"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Years(Value * 50).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Years(0).FromRootBaseValue(value / 50);
        }

        public Jubilee(double value) : base(value)
        {

        }
    }
}
