namespace NLUC.Units.Mass.Archaic
{
    internal class Grains : Unit
    {
        public override Units DerivedUnits => Units.Grain;

        public override Units RootBase => Units.Kilogram;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "gr",
                    "grains",
                    "grain"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Milligrams(Value * 64.79891).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Milligrams(0).FromRootBaseValue(value / 64.79891);
        }

        public Grains(double value) : base(value)
        {

        }
    }
}
