namespace NLUC.Units.Length
{
    internal class Millimetres : Unit
    {
        public override Units DerivedUnits => Units.Millimetres;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "mm",
                    "millimetre",
                    "millimetres"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Centimetres(Value / 10).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Centimetres(0).FromRootBaseValue(value * 10);
        }

        public Millimetres(double value) : base(value)
        {

        }
    }
}
