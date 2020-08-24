using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class Reservation
    {
        private int id;
        private DateTime dateDebut;
        private DateTime dateFin;
        private StatutReservation statut;
        
        private Client client;

        public int Id { get => id; set => id = value; }
        public DateTime DateDebut { get => dateDebut; set => dateDebut = value; }
        public DateTime DateFin { get => dateFin; set => dateFin = value; }
        public Client Client { get => client; set => client = value; }
        public StatutReservation Statut { get => statut; set => statut = value; }

        public Reservation()
        {

        }

        public override string ToString()
        {
            return "Numero : "+Id + " " +
                "Date de début : "+DateDebut +" " +
                "Date de Fin : "+DateFin +" "+
                "Satut " + Statut + "\n" +
                "Client : "+Client.ToString();
        }
    }

    enum StatutReservation
    {
        Valide,
        Annule,
    }
}
