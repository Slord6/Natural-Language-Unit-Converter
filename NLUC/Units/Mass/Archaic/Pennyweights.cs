namespace NLUC.Units.Mass.Archaic
{
    internal class Pennyweights : Unit
    {
        public override Units DerivedUnits => Units.Pennyweight;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "dwt",
                    "pennyweight",
                    "pennyweights",
                    "pwt",
                    "PW"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Grains(Value * 24).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Grains(0).FromRootBaseValue(value / 24);
        }

        public Pennyweights(double value) : base(value)
        {

        }
    }
}
