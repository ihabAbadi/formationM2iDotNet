using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace CompteBancaireWPF.Classes
{
    public class Sauvegarde
    {
        private static Sauvegarde _instance = null;
        private static SqlCommand command;
        private static SqlDataReader reader;
        public static Sauvegarde Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Sauvegarde();
                return _instance;
            }
        }
        private Sauvegarde()
        {

        }

        public bool CreationCompte(Compte compte)
        {
            if(CreationClient(compte.Client))
            {
                string request = "INSERT INTO Compte (Numero, Solde, Client_id) " +
                    "OUTPUT INSERTED.ID values (@numero, @solde,@clientId)";
                command = new SqlCommand(request, Connection.Instance);
                command.Parameters.Add(new SqlParameter("@numero", compte.Numero));
                command.Parameters.Add(new SqlParameter("@solde", compte.Solde));
                command.Parameters.Add(new SqlParameter("@clientId", compte.Client.Id));
                Connection.Instance.Open();
                compte.Id = (int)command.ExecuteScalar();
                command.Dispose();
                Connection.Instance.Close();
                //if(compte is CompteEpargne compteEpargne)
                //{
                //    compteEpargne.CompteId = compte.Id;
                //    CreationCompteEpargne(compteEpargne);
                //}
                //else if(compte is ComptePayant comptePayant)
                //{
                //    comptePayant.CompteId = compte.Id;
                //    CreationComptePayant(comptePayant);
                //}
            }
            return compte.Id > 0;
        }

        public bool CreationClient(Client client)
        {
            string request = "INSERT INTO client (Nom, Prenom, Telephone) " +
                "OUTPUT INSERTED.ID values(@nom, @prenom, @telephone)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@nom", client.Nom));
            command.Parameters.Add(new SqlParameter("@prenom", client.Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", client.Telephone));
            Connection.Instance.Open();
            client.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            return client.Id > 0;
        }

        //public bool CreationCompteEpargne(CompteEpargne compte)
        //{
        //    string request = "INSERT INTO compteEpargne (compte_id, taux) " +
        //        "OUTPUT INSERTED.ID values(@compteId, @taux)";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@compteId", compte.CompteId));
        //    command.Parameters.Add(new SqlParameter("@taux", compte.Taux));
        //    Connection.Instance.Open();
        //    compte.Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return compte.Id > 0;
        //}

        //public bool CreationComptePayant(ComptePayant compte)
        //{
        //    string request = "INSERT INTO comptePayant (compte_id, cout) " +
        //        "OUTPUT INSERTED.ID values(@compteId, @cout)";
        //    command = new SqlCommand(request, Connection.Instance);
        //    command.Parameters.Add(new SqlParameter("@compteId", compte.CompteId));
        //    command.Parameters.Add(new SqlParameter("@cout", compte.CoutOperation));
        //    Connection.Instance.Open();
        //    compte.Id = (int)command.ExecuteScalar();
        //    command.Dispose();
        //    Connection.Instance.Close();
        //    return compte.Id > 0;
        //}

        public Compte ChercherCompte(string numero)
        {
            Compte compte = null;
            string  request = "SELECT c.id, c.solde, cl.id, cl.Nom, cl.Prenom, cl.Telephone" +
                " FROM compte as c " +
                "inner join client as cl on c.client_id=cl.id " +
                "where numero=@numero";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@numero", numero));
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                compte = new Compte()
                {
                    Id = reader.GetInt32(0),
                    Solde = reader.GetDecimal(1),
                    Numero = numero,
                };
                compte.Client = new Client()
                {
                    Id = reader.GetInt32(2),
                    Nom = reader.GetString(3),
                    Prenom = reader.GetString(4),
                    Telephone = reader.GetString(5)
                };
            }
            reader.Close();
            command.Dispose();

            Connection.Instance.Close();
            return compte;
        }


        public ObservableCollection<Compte> ChercherComptes(string numero = null)
        {
            ObservableCollection<Compte> liste = new ObservableCollection<Compte>();
            string request = "SELECT c.id, c.solde, cl.id, cl.Nom, cl.Prenom, cl.Telephone" +
                " FROM compte as c " +
                "inner join client as cl on c.client_id=cl.id ";
            if(numero != null)  
                request +="where numero like @numero";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@numero", numero +"%"));
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                Compte compte = new Compte()
                {
                    Id = reader.GetInt32(0),
                    Solde = reader.GetDecimal(1),
                    Numero = numero,
                };
                compte.Client = new Client()
                {
                    Id = reader.GetInt32(2),
                    Nom = reader.GetString(3),
                    Prenom = reader.GetString(4),
                    Telephone = reader.GetString(5)
                };
                liste.Add(compte);
            }
            reader.Close();
            command.Dispose();

            Connection.Instance.Close();
            return liste;
        }

        public List<Operation> getOperations(int compteId)
        {
            List<Operation> operations = new List<Operation>();
            string request = "SELECT * FROM operation where compte_id=@compte_id";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@compte_id", compteId));
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                Operation o = new Operation(reader.GetDecimal(2), compteId)
                {
                    Id = reader.GetInt32(0)
                };
                operations.Add(o);
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            return operations;
        }

        public bool addOperation(Operation operation)
        {
            string request = "INSERT INTO operation (compte_id, montant) OUTPUT INSERTED.ID " +
                "values (@compte_id, @montant)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@compte_id", operation.CompteId));
            command.Parameters.Add(new SqlParameter("@montant", operation.Montant));
            Connection.Instance.Open();
            operation.Id = (int)command.ExecuteScalar();
            command.Dispose();
            int nbRow = 0;
            if(operation.Id > 0)
            {
                request = "UPDATE compte set solde=solde+@montant where id=@id";
                command = new SqlCommand(request, Connection.Instance);
                command.Parameters.Add(new SqlParameter("@montant", operation.Montant));
                command.Parameters.Add(new SqlParameter("@id", operation.CompteId));
                nbRow = command.ExecuteNonQuery();
                command.Dispose();
            }
            Connection.Instance.Close();
            return operation.Id > 0 && nbRow == 1;        
        }

    }
}
