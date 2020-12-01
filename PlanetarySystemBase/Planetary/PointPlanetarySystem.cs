namespace PlanetarySystem.Planetary
{
    public class PointPlanetarySystem<T> : PlanetarySystem<T> where T : PointSimulationElement
    {
        public double Distance(int i1, int i2)
        {
            PointSimulationElement p1 = GetElement(i1);
            PointSimulationElement p2 = GetElement(i2);
            return p1.Distance(p2);
        }
    }
}