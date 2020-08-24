using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class Hotel
    {
        private string nom;
        private List<Client> clients;
        private List<Reservation> reservations;

        public string Nom { get => nom; set => nom = value; }
        public List<Client> Clients { get => clients; set => clients = value; }
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

        public Hotel(string n)
        {
            Nom = n;
            List<Client> clientsTmp = Sauvegarde.Instance.RecuperationClients(Nom);
            List<Reservation> reservationsTmp = Sauvegarde.Instance.RecuperationReservations(Nom);
            Clients = (clientsTmp == null) ? new List<Client>() : clientsTmp;
            Reservations = (reservationsTmp == null) ? new List<Reservation>() : reservationsTmp;

        }
        public void SauvegardeClient(Client client)
        {
            client.Id = (Clients.Count == 0) ? 1 : Clients[Clients.Count - 1].Id + 1;
            Clients.Add(client);
            Sauvegarde.Instance.SauvegardeClients(this);
        }

        public void SauvegardeReservation(Reservation reservation)
        {
            reservation.Id = (Reservations.Count == 0) ? 1 : Reservations[Reservations.Count - 1].Id + 1;
            Reservations.Add(reservation);
            Sauvegarde.Instance.SauvegardeReservations(this);
            Sauvegarde.Instance.SauvegardeClients(this);
        }

        public void UpdateStatutReservation()
        {
            Sauvegarde.Instance.SauvegardeReservations(this);
        }

        public Reservation GetReservationById(int id)
        {
            Reservation reservation = null;
            foreach(Reservation r in Reservations)
            {
                if(r.Id == id)
                {
                    reservation = r;
                    break;
                }
            }
            return reservation;
        }

        public Client GetClientById(int id)
        {
            Client client = null;
            foreach(Client c in Clients)
            {
                if(c.Id == id)
                {
                    client = c;
                    break;
                }
            }
            return client;
        }

        public void SupprimerClient(Client client)
        {
            if(Clients.Remove(client))
            {
                Sauvegarde.Instance.SauvegardeClients(this);
            }
            else
            {
                throw new Exception("Erreur suppression client");
            }
        }

        public void GetReservationClient(Client client)
        {
            foreach(Reservation r in Reservations)
            {
                if(r.Client.Id == client.Id)
                {
                    client.Reservations.Add(r);
                }
            }
        }
    }
}
