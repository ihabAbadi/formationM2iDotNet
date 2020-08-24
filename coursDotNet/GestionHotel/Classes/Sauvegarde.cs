using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GestionHotel.Classes
{
    class Sauvegarde
    {
        private static Sauvegarde instance = null;

        private StreamWriter writer;
        private StreamReader reader;

        public static Sauvegarde Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Sauvegarde();
                }
                return instance;
            }
        }
        private Sauvegarde()
        {
            if(!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
        }
        public void SauvegardeClients(Hotel hotel)
        {
            string chaine = JsonConvert.SerializeObject(hotel.Clients);
            writer = new StreamWriter(Path.Combine("files", "clients-" + hotel.Nom + ".json"));
            writer.Write(chaine);
            writer.Close();
        }

        public void SauvegardeReservations(Hotel hotel)
        {
            string chaine = JsonConvert.SerializeObject(hotel.Reservations);
            writer = new StreamWriter(Path.Combine("files", "reservations-" + hotel.Nom + ".json"));
            writer.Write(chaine);
            writer.Close();
        }

        public List<Client> RecuperationClients(string nomHotel)
        {
            if(File.Exists(Path.Combine("files", "clients-" + nomHotel + ".json")))
            {
                reader = new StreamReader(Path.Combine("files", "clients-" + nomHotel+ ".json"));
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(reader.ReadToEnd());
                reader.Close();
                return clients;
            }
            return null;
        }

        public List<Reservation> RecuperationReservations(string nomHotel)
        {
            if (File.Exists(Path.Combine("files", "reservations-" + nomHotel + ".json")))
            {
                reader = new StreamReader(Path.Combine("files", "reservations-" + nomHotel + ".json"));
                List<Reservation> reservations= JsonConvert.DeserializeObject<List<Reservation>>(reader.ReadToEnd());
                reader.Close();
                return reservations;
            }
            return null;
        }

        
    }
}
