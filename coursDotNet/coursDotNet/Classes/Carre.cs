using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Carre: Figure, IDeformable
    {
        private double longueur;

        public Carre(int px, int py,double longueur):base(px,py)
        {
            Longueur = longueur;
        }

        public double Longueur { get => longueur; set => longueur = value; }

        public override void Afficher()
        {
            Console.WriteLine("Je suis un carré de longueur : "+ Longueur);
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
            Figure figure;
            if(coeffH == coeffV)
            {
                figure = new Carre(PosX, PosY, Longueur * coeffV);
            }
            else
            {
                figure = new Rectangle(PosX, PosY, Longueur * coeffH, Longueur * coeffV);
            }
            return figure;
        }
    }
}
