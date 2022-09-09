namespace NLUC.Units.Length.Archaic
{
    internal class Barleycorns : Unit
    {
        public override Units DerivedUnits => Units.Barleycorn;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "barleycorn",
                    "barleycorns"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Millimetres(Value * 8.47).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Millimetres(0).FromRootBaseValue(value / 8.47);
        }

        public Barleycorns(double value) : base(value)
        {

        }
    }
}
