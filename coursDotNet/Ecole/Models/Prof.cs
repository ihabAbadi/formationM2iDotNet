using Ecole.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole.Models
{
    class Prof: Personne
    {
        private int personneId;
        private Matiere matiere;

        public int PersonneId { get => personneId; set => personneId = value; }
        public Matiere Matiere { get => matiere; set => matiere = value; }

        public override bool Save()
        {
            if (base.Save())
            {
                PersonneId = Id;
                string request = "INSERT INTO prof (personne_id, matiere_id) OUTPUT INSERTED.ID values(@personne_id, @matiere_id)";
                command = new SqlCommand(request, Connection.Instance);
                command.Parameters.Add(new SqlParameter("@personne_id", PersonneId));
                command.Parameters.Add(new SqlParameter("@matiere_id", Matiere.Id));
                Connection.Instance.Open();
                Id = (int)command.ExecuteScalar();
                command.Dispose();
                Connection.Instance.Close();
                return Id > 0;
            }
            return false;
        }

        public static List<Prof> GetProfs()
        {
            List<Prof> liste = new List<Prof>();
            string request = "SELECT p.id,p.nom, p.prenom,p.telephone, p.email, p.adresse, p.code_postal, p.ville," +
                " e.id, c.id, c.nom FROM personne as p " +
                "inner join prof as e on p.id =e.personne_id " +
                "inner join matiere as c on c.id = e.matiere_id";
            command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Prof p = new Prof()
                {
                    Id = reader.GetInt32(8),
                    PersonneId = reader.GetInt32(0),
                    Nom = reader.GetString(1),
                    Prenom = reader.GetString(2),
                    Telephone = reader.GetString(3),
                    Email = reader.GetString(4),
                    Adresse = reader.GetString(5),
                    CodePostal = reader.GetString(6),
                    Ville = reader.GetString(7),
                    Matiere = new Matiere() { Id = reader.GetInt32(9), Nom = reader.GetString(10) }
                };
                liste.Add(p);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return liste;
        }
    }
}
