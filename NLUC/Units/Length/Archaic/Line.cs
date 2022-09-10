namespace NLUC.Units.Length.Archaic
{
    internal class Line : Unit
    {
        public override Units DerivedUnits => Units.Line;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "lines",
                    "line"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Barleycorns(Value / 4).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Barleycorns(0).FromRootBaseValue(value * 4);
        }

        public Line(double value) : base(value)
        {

        }
    }
}
