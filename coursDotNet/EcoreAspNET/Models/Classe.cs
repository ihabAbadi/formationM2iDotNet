using Ecole.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole.Models
{
    public class Classe
    {
        private int id;
        private string nom;

        private static SqlCommand command;
        private static SqlDataReader reader;
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public static List<Classe> GetClasses()
        {
            List<Classe> liste = new List<Classe>();
            string request = "SELECT * FROM Classe";
            command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classe c = new Classe()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1)
                };
                liste.Add(c);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return liste;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
