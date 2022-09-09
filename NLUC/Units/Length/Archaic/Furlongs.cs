namespace NLUC.Units.Length.Archaic
{
    internal class Furlongs : Unit
    {
        public override Units DerivedUnits => Units.Furlong;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "furlongs",
                    "furlong"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Rods(Value * 40).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Rods(0).FromRootBaseValue(value / 40);
        }

        public Furlongs(double value) : base(value)
        {

        }
    }
}
