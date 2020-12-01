using System.Collections.Generic;

namespace PlanetarySystem.Planetary
{
    public class PlanetarySystem<T> : ISimulationElement where T : ISimulationElement
    {
        protected List<T> Elemendid;

        public PlanetarySystem()
        {
            Elemendid = new List<T>();
        }

        #region ISimulationElement Members

        public void Tick()
        {
            foreach (T e in Elemendid)
            {
                e.Tick();
            }
        }

        #endregion

        public void Append(T element)
        {
            Elemendid.Add(element);
        }

        public T GetElement(int indeks)
        {
            return Elemendid[indeks];
        }

        public int Size()
        {
            return Elemendid.Count;
        }
    }
}