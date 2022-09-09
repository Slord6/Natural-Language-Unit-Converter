namespace NLUC.Units.Time
{
    internal class Semesters : Unit
    {
        public override Units DerivedUnits => Units.Semester;

        public override Units RootBase => Units.Second;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "semesters",
                    "semester"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Weeks(Value * 18).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Weeks(0).FromRootBaseValue(value / 18);
        }

        public Semesters(double value) : base(value)
        {

        }
    }
}
