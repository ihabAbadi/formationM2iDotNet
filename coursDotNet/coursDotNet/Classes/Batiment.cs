using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class Batiment
    {
        private string adresse;

        public string Adresse { get => adresse; set => adresse = value; }

        public Batiment()
        {

        }
        public Batiment(string adresse)
        {
            Adresse = adresse;
        }
        public override string ToString()
        {
            return "Adresse : "+ Adresse;
        }
    }
}
