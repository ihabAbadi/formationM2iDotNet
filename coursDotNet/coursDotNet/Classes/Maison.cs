using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Maison : Batiment, IAffichable
    {
        private int nbPieces;

        public int NbPieces { get => nbPieces; set => nbPieces = value; }

        public Maison()
        {

        }

        public Maison(int nbPieces, string adresse) : base(adresse)
        {
            NbPieces = nbPieces;
        }

        public override string ToString()
        {
            string retour = base.ToString();
            retour += " Nombre de pièces : " + NbPieces;
            return retour;
        }

        public void Afficher()
        {
            Console.WriteLine(this);
        }
    }
}
