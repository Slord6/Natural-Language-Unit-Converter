namespace NLUC.Units.Time
{
    internal class Millenia : Unit
    {
        public override Units DerivedUnits => Units.Millenium;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "millenia",
                    "millenium"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Centuries(Value * 10).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Centuries(0).FromRootBaseValue(value / 10);
        }

        public Millenia(double value) : base(value)
        {

        }
    }
}
