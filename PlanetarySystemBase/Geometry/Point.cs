using System;

namespace PlanetarySystem.Geometry
{
    public class Point
    {
        public Point()
        {
            Rho = 0.0;
            Theta = 0.0;
        }

        public Point(double x, double y)
        {
            SetFromXY(x, y);
        }

        public double Rho { get; set; }
        public double Theta { get; set; }

        private void SetFromXY(double x, double y)
        {
            Rho = Math.Sqrt(Math.Pow(x, 2.0) + Math.Pow(y, 2.0));
            Theta = Math.Atan2(y, x);
        }

        public double GetRho()
        {
            return Rho;
        }

        public double GetTheta()
        {
            return Theta;
        }

        public double GetX()
        {
            return GetRho()*Math.Cos(GetTheta());
        }

        public double GetY()
        {
            return GetRho()*Math.Sin(GetTheta());
        }

        public double Distance(Point p)
        {
            return VectorTo(p).GetRho();
        }

        public Point VectorTo(Point p)
        {
            return new Point(p.GetX() - GetX(), p.GetY() - GetY());
        }

        public void Translate(double dx, double dy)
        {
            double x = GetX() + dx;
            double y = GetY() + dy;
            SetFromXY(x, y);
        }

        public void Scale(double factor)
        {
            Rho *= factor;
        }

        public void CentreRotate(double angle)
        {
            Theta += angle;
        }

        public void Rotate(Point p, double angle)
        {
            Translate(-p.GetX(), -p.GetY());
            CentreRotate(angle);
            Translate(p.GetX(), p.GetY());
        }
    }
}