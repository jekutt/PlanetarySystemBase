using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetarySystem.Planetary
{
    internal class SpaceShip : PointSimulationElement
    {
        internal double _dx;
        internal double _dy;
        public SpaceShip(double x, double y, double dx, double dy) : base(x, y)
        {
            _dx = dx;
            _dy = dy;
        }
        //Ülesanded: Liikuda simulatsiooniga ühe atomaarse sammu võrra edasi, muutes sobivalt planeedisüsteemi elementide koordinaate.
        //Eeltingimused: -
        //Järeltingimused: Kõik kosmoselaevad on liikunud dx ja dy võrra.

        public override void Tick()
        {
            Translate(_dx, _dy);
        }
    }
}
