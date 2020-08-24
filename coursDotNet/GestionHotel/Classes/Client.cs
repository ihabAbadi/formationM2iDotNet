using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace GestionHotel.Classes
{
    class Client 
    {
        private int id;

        private string nom;

        private string prenom;

        private string telephone;

        private List<Reservation> reservations;

        public Client()
        {
            Reservations = new List<Reservation>();
        }
        public Client(string n, string p, string t) : this()
        {
            Nom = n;
            Prenom = p;
            Telephone = t;
        }

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }

        [JsonIgnore]
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

       

        public override string ToString()
        {
            return "Id : " + Id + " " +
                "Nom : " + Nom + " " +
                "Prénom : "+ Prenom + " " +
                "Téléphone : "+ Telephone;
        }


    }
}
