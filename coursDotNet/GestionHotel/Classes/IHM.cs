using System;
using System.Collections.Generic;
using System.Text;

namespace GestionHotel.Classes
{
    class IHM
    {
        Hotel hotel;
        
        public void Start()
        {
            Console.Write("Merci de saisir le nom de l'hotel : ");
            string nom = Console.ReadLine();
            hotel = new Hotel(nom) ;
            hotel.HotelPlein += EnvoieMailHotelPlein;
            hotel.PlaceRest += EnvoieMailPlaceRest;
            MenuPrincipal();
        }

        

        public void MenuPrincipal()
        {
            string choix;
            do
            {
                Console.Clear();
                Console.WriteLine("----- Bienvenue dans notre hotel ! -----");
                Console.WriteLine();
                Console.WriteLine("--- GESTION CLIENTS ---");
                Console.WriteLine("1 -- Ajouter un client");
                Console.WriteLine("2 -- Afficher la liste des clients");
                Console.WriteLine("3 -- Afficher les reservations d'un client");
                Console.WriteLine("4 -- Supprimer un client");

                Console.WriteLine();
                Console.WriteLine("--- GESTION RESERVATIONS ---");
                Console.WriteLine("5 -- Ajouter une réservation");
                Console.WriteLine("6 -- Afficher toutes les réservations");
                Console.WriteLine("7 -- Afficher toutes les résérvations actives");
                Console.WriteLine("8 -- Annuler une réservation");
                Console.WriteLine();
                Console.WriteLine("0 -- Quitter");
                Console.WriteLine();
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        AjouterClient();
                        break;
                    case "2":
                        AfficherListeClient();
                        RetourMenu();
                        break;
                    case "3":
                        AfficherReservationsClient();
                        break;
                    case "4":
                        SupprimerClient();
                        break;
                    case "5":
                        AjouterReservation();
                        break;
                    case "6":
                        AfficherListeReservations();
                        RetourMenu();
                        break;
                    case "7":
                        AfficherReservationsActives();
                        break;
                    case "8":
                        AnnulerReservation();
                        break;
                }
            }
            while (choix != "0");
        }

        private void AjouterClient()
        {
            Console.WriteLine("Le nom de client : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Le prénom de client : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Le téléphone du client : ");
            string telephone = Console.ReadLine();
            Client client = new Client(nom, prenom, telephone);
            hotel.SauvegardeClient(client);
            Console.WriteLine("Le client sauvegardé avec le numéro : " + client.Id);
            RetourMenu();
        }

        private void AfficherListeClient()
        {
            foreach (Client c in hotel.Clients)
            {
                Console.WriteLine(c);
            }
        }

        private void AfficherReservationsClient()
        {
            AfficherListeClient();
            Console.WriteLine("Réservations de quel client voulez-vous régarder ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Client client = hotel.GetClientById(id);
            Console.WriteLine(client);
            hotel.GetReservationClient(client);
            if(client.Reservations.Count == 0)
            {
                Console.WriteLine("Aucune reservation");
            }
            foreach (Reservation r in client.Reservations)
            {   
                Console.WriteLine(r);
            }
            RetourMenu();
        }

        private void SupprimerClient()
        {
            AfficherListeClient();
            Console.WriteLine("Quel client voulez-vous supprimer ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Client client = hotel.GetClientById(id);
            try
            {
                hotel.SupprimerClient(client);
                Console.WriteLine("Client supprimé");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            RetourMenu();
        }

        private void AjouterReservation()
        {
            AfficherListeClient();
            Console.WriteLine("Pour quel client voulez-vous faire la réservation ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Client client = hotel.GetClientById(id);
            Console.WriteLine("La date de début de séjour : ");
            DateTime debut = CreerDate();
            Console.WriteLine("La date de fin de séjour : ");
            DateTime fin = CreerDate();
            Reservation reservation = new Reservation() { Client = client, DateDebut = debut, DateFin = fin, Statut = StatutReservation.Valide };    
            client.Reservations.Add(reservation);
            hotel.SauvegardeReservation(reservation);
            Console.WriteLine("La réservation a été sauvgardée avec le numéro : "+ reservation.Id);
            RetourMenu();
        }

        private void AfficherListeReservations()
        {
            foreach (Reservation r in hotel.Reservations)
            {
                Console.WriteLine(r);
            }
        }

        private void AfficherReservationsActives()
        {
            bool found = false;
            foreach (Reservation r in hotel.Reservations)
            {
                if (r.Statut == StatutReservation.Valide)
                {
                    Console.WriteLine(r);
                    found = true;
                }
            }
            if (found == false)
            {
                Console.WriteLine("Il n'y a pas de résérvations actives.");
            }
            RetourMenu();
        }

        private void AnnulerReservation()
        {
            AfficherListeReservations();
            Console.WriteLine("Quelle réservation voulez-vous annuler ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Reservation reservation = hotel.GetReservationById(id);
            if(reservation != null)
            {
                reservation.Statut = StatutReservation.Annule;
                hotel.UpdateStatutReservation();
                Console.WriteLine("La réservation a été annulée");
            }
            else
            {
                Console.WriteLine("Aucune reservation avec cet id");
            }

            RetourMenu();
        }

        private DateTime CreerDate()
        {
            DateTime date;
            try
            {
                Console.WriteLine("Jour : ");
                Int32.TryParse(Console.ReadLine(), out int jour);
                Console.WriteLine("Mois : ");
                Int32.TryParse(Console.ReadLine(), out int mois);
                Console.WriteLine("Année : ");
                Int32.TryParse(Console.ReadLine(), out int annee);
                date = new DateTime(annee, mois, jour);
            }
            catch (FormatException ex)
            {
                date = new DateTime(0000, 00, 00);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                date = new DateTime(0000, 00, 00);
                Console.WriteLine(ex.Message);
            }
            return date;
        }

        private void RetourMenu()
        {
            Console.WriteLine("Appuyez sur Entrée pour retourner au menu");
            Console.ReadLine();
        }

        private void EnvoieMailHotelPlein(string nom)
        {
            Console.WriteLine("L'hotel " + nom + " est plein");
        }

        private void EnvoieMailPlaceRest(int nbrePlace, string nom)
        {
            Console.WriteLine("Il reste " + nbrePlace + " dans l'hotel " + nom);
        }
    }
}
