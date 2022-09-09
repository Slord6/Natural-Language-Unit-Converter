namespace NLUC.Units.Length
{
    internal class NauticalMiles : Unit
    {
        public override Units DerivedUnits => Units.NauticalMile;

        public override Units RootBase => Units.Metre;

        public override string[] Shorthand
        {
            get
            {
                return new string[]
                {
                    "nmi",
                    "nautical miles",
                    "nautical mile",
                    "NM",
                    "M"
                };
            }
        }

        public override IUnit ToSIBase()
        {
            return new Metres(Value * 1852).ToSIBase();
        }

        public override double FromRootBaseValue(double value)
        {
            return new Metres(0).FromRootBaseValue(value / 1852);
        }

        public NauticalMiles(double value) : base(value)
        {

        }
    }
}
