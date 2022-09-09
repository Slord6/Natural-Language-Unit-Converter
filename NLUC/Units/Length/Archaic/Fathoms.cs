namespace NLUC.Units.Length.Archaic
{
    internal class Fathoms : Unit
    {
        public override Units DerivedUnits => Units.Fathom;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "fathoms",
                    "fathom"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Feet(Value * 6).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Feet(0).FromRootBaseValue(value / 6);
        }

        public Fathoms(double value) : base(value)
        {

        }
    }
}
