using Ecole.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole.Models
{
    public class Matiere
    {
        private int id;
        private string nom;
        private static SqlCommand command;
        private static SqlDataReader reader;


        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }

        public static List<Matiere> getMatieres()
        {
            List<Matiere> matieres = new List<Matiere>();
            string request = "SELECT * FROM Matiere";
            command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Matiere m = new Matiere()
                {
                    Id = reader.GetInt32(0),
                    Nom = reader.GetString(1)
                };
                matieres.Add(m);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return matieres;
        }
        public override string ToString()
        {
            return Nom;
        }
    }
}
