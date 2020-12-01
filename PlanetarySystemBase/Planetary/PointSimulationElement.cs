using PlanetarySystem.Geometry;

namespace PlanetarySystem.Planetary
{
    public abstract class PointSimulationElement : Point, ISimulationElement
    {
        protected PointSimulationElement(double x, double y) : base(x, y) { }

        #region ISimulationElement Members

        public abstract void Tick();

        #endregion
    }
}