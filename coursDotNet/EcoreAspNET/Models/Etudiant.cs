using Ecole.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecole.Models
{
    public class Etudiant : Personne
    {
        private int personneId;

        private Classe classe;

        public int PersonneId { get => personneId; set => personneId = value; }
        public Classe Classe { get => classe; set => classe = value; }

        public override bool Save()
        {
            if (base.Save())
            {
                PersonneId = Id;
                string request = "INSERT INTO etudiant (personne_id, classe_id) OUTPUT INSERTED.ID values(@personne_id, @classe_id)";
                command = new SqlCommand(request, Connection.Instance);
                command.Parameters.Add(new SqlParameter("@personne_id", PersonneId));
                command.Parameters.Add(new SqlParameter("@classe_id", Classe.Id));
                Connection.Instance.Open();
                Id = (int)command.ExecuteScalar();
                command.Dispose();
                Connection.Instance.Close();
                return Id > 0;
            }
            return false;
        }

        public static List<Etudiant> GetEtudiants()
        {
            List<Etudiant> liste = new List<Etudiant>();
            string request = "SELECT p.id,p.nom, p.prenom,p.telephone, p.email, p.adresse, p.code_postal, p.ville," +
                " e.id, c.id, c.nom FROM personne as p " +
                "inner join etudiant as e on p.id =e.personne_id " +
                "inner join classe as c on c.id = e.classe_id";
            command = new SqlCommand(request, Connection.Instance);
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Etudiant e = new Etudiant()
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
                    Classe = new Classe() { Id = reader.GetInt32(9), Nom = reader.GetString(10)}
                };
                liste.Add(e);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return liste;
        }

        public bool Update()
        {
            if(Update(PersonneId))
            {
                string request = "UPDATE Etudiant set classe_id=@classe_id " +
                "where id=@id";
                command = new SqlCommand(request, Connection.Instance);
                command.Parameters.Add(new SqlParameter("@classe_id", Classe.Id));
                command.Parameters.Add(new SqlParameter("@id", Id));
                Connection.Instance.Open();
                int nbRow = command.ExecuteNonQuery();
                command.Dispose();
                Connection.Instance.Close();
                return nbRow == 1;
            }
            return false;
        }
    }
}
