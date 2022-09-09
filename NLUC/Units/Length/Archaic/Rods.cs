namespace NLUC.Units.Length.Archaic
{
    internal class Rods : Unit
    {
        public override Units DerivedUnits => Units.Rod;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "rods",
                    "rod",
                    "perches",
                    "perch",
                    "pole",
                    "poles"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Yards(Value * 5.5).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Yards(0).FromRootBaseValue(value / 5.5);
        }

        public Rods(double value) : base(value)
        {

        }
    }
}
