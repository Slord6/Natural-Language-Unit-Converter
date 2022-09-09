namespace NLUC.Units.Length.Archaic
{
    internal class Chains : Unit
    {
        public override Units DerivedUnits => Units.Chain;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "chains",
                    "chain"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Rods(Value * 4).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Rods(0).FromRootBaseValue(value / 4);
        }

        public Chains(double value) : base(value)
        {

        }
    }
}
