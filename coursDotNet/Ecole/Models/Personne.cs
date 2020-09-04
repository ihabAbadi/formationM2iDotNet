using Ecole.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole.Models
{
    abstract class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private string email;
        private string adresse;
        private string codePostal;
        private string ville;
        protected static SqlCommand command;
        protected static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string CodePostal { get => codePostal; set => codePostal = value; }
        public string Ville { get => ville; set => ville = value; }

        public virtual bool Save()
        {
            string request = "INSERT INTO Personne(nom, prenom, telephone, email, adresse, code_postal, ville) " +
                "OUTPUT INSERTED.ID values (@nom, @prenom, @telephone, @email, @adresse, @code_postal, @ville)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@email", Email));
            command.Parameters.Add(new SqlParameter("@adresse", Adresse));
            command.Parameters.Add(new SqlParameter("@code_postal", CodePostal));
            command.Parameters.Add(new SqlParameter("@ville", Ville));
            Connection.Instance.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            return Id > 0;
        }
    }
}
