using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Triangle : Figure, IDeformable
    {
        private double baseTriangle;
        private double hauteur;

        public double BaseTriangle { get => baseTriangle; set => baseTriangle = value; }
        public double Hauteur { get => hauteur; set => hauteur = value; }

        public Triangle(int px, int py, double baseTriangle, double hauteur):base(px,py)
        {
            BaseTriangle = baseTriangle;
            Hauteur = hauteur;
        }

        public override void Afficher()
        {
            Console.WriteLine("Je suis un triangle de base : "+BaseTriangle + " et de hauteur : "+ Hauteur);
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
            return new Triangle(PosX, PosY, BaseTriangle * coeffH, Hauteur * coeffV);
        }
    }
}
