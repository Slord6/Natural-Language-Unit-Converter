namespace NLUC.Units.Length.Archaic
{
    internal class Leagues : Unit
    {
        public override Units DerivedUnits => Units.League;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "leagues",
                    "league"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Miles(Value * 3).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Miles(0).FromRootBaseValue(value / 3);
        }

        public Leagues(double value) : base(value)
        {

        }
    }
}
