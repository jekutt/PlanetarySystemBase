using System;
using System.Runtime.CompilerServices;

namespace PlanetarySystem.Planetary
{
    public class PSController
    {
        // T määrab, mitu atomaarset Tick sammu on Maa aastas
        private const double T = 4;

        // Planeedisüsteem, millel simulatsioon toimub
        private PlanetarySystem<PointSimulationElement> _planetarySystem;


        // Fassaadmeetod, mis loob uue planeedisüsteemi
        public void MakeSolarSystem()
        {
            if (GetPlanetarySystem() == null)
            {
                _planetarySystem = new PlanetarySystem<PointSimulationElement>();
                GetPlanetarySystem().Append(new Planet(0.39, 0.0, (2.0*Math.PI)/(87.97/365.26)*T));
                GetPlanetarySystem().Append(new Planet(0.72, 0.0, (2.0*Math.PI)/(227.7/365.26)*T));
                GetPlanetarySystem().Append(new Planet(1.0, 0.0, (2.0*Math.PI)/(1.0)*T));
                GetPlanetarySystem().Append(new Planet(1.52, 0.0, (2.0*Math.PI)/(686.98/365.26)*T));
                GetPlanetarySystem().Append(new Planet(5.2, 0.0, (2.0*Math.PI)/(11.86)*T));
                GetPlanetarySystem().Append(new Planet(9.54, 0.0, (2.0*Math.PI)/(29.46)*T));
                GetPlanetarySystem().Append(new Planet(19.18, 0.0, (2.0*Math.PI)/(84.01)*T));
                GetPlanetarySystem().Append(new Planet(30.06, 0.0, (2.0*Math.PI)/(164.81)*T));
                GetPlanetarySystem().Append(new Planet(39.75, 0.0, (2.0*Math.PI)/(247.7)*T));
            }
        }

        internal SpaceShip Launch(int planet_id, double dx, double dy)
        {
            // pre
            //  Töös olev planeedisüsteem omab planeeti indeksiga planet_id
            // post 
            //  On tekitatud kosmoselaev, mille koordinaadid vastavad indeksiga planet_id määratud planeedi omadele ja mille kiirusvektor on(dx, dy).
            //  Tekitatud kosmoselaev on lisatud töös olevasse planeedisüsteemi.
            //  Tekitatud kosmoselaev on operatsiooni tulemiks.


            try
            {
                SpaceShip ship = new SpaceShip(_planetarySystem.GetElement(planet_id).GetX(),
                    _planetarySystem.GetElement(planet_id).GetY(), dx, dy);
                _planetarySystem.Append(ship);
                return ship;
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
        }


        // Fassaadmeetod, mis liigutab planeedisüsteemi objekte ühe atomaarse sammu võrra
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Tick()
        {
            GetPlanetarySystem().Tick();
        }

        public PlanetarySystem<PointSimulationElement> GetPlanetarySystem()
        {
            return _planetarySystem;
        }
    }
}