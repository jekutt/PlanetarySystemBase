namespace PlanetarySystem.Planetary
{
    internal class Planet : PointSimulationElement
    {
        private readonly double _omega;

        public Planet(double x, double y, double omega) : base(x, y)
        {
            _omega = omega;
        }

        public double GetOmega()
        {
            return _omega;
        }

        public override void Tick()
        {
            CentreRotate(_omega);
        }
    }
}