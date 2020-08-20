using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Rectangle : Figure, IDeformable
    {
        private double largeur;
        private double hauteur;

        public double Largeur { get => largeur; set => largeur = value; }
        public double Hauteur { get => hauteur; set => hauteur = value; }

        public Rectangle(int px, int py, double largeur, double hauteur) : base(px, py)
        {
            Largeur = largeur;
            Hauteur = hauteur;
        }

        public override void Afficher()
        {
            Console.WriteLine("Rectange de largeur : " + largeur + "et hauteur : " + hauteur);
        }

        public Figure Deformation(double coeffH, double coeffV)
        {
            Figure figure;
            if(Largeur * coeffH == Hauteur * coeffV)
            {
                figure = new Carre(PosX, PosY, Largeur * coeffH);
            }
            else
            {
                figure = new Rectangle(PosX, PosY, Largeur * coeffH, Hauteur * coeffV);
            }
            return figure;
        }
    }
}
