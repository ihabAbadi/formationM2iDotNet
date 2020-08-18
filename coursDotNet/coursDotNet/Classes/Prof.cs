using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Prof : Personne
    {
        private string matiere;
        public string Matiere { get => matiere; set => matiere = value; }

        public Prof()
        {

        }

        public Prof(string n, string p, string m) : base(n,p)
        {
            Matiere = m;
        }

        //surcharge de la méthode Afficher avec override qui étend la métohde de la classe mère
        public override void Afficher()
        {
            base.Afficher();
            Console.WriteLine("Matière : " + Matiere);
        }

        //surcharge de la méthode AfficherWithNew avec new qui masque la méthode de la classe mère
        public new void AfficherWithNew()
        {
            base.Afficher();
            Console.WriteLine("Matière : " + Matiere);
        }

        public void SpecialProf()
        {
            Console.WriteLine("Speciale Prof");
        }
    }
}
