using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class Sauvegarde
    {
        private static Sauvegarde _instance = null;
        private static SqlCommand command;
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
                if(compte is CompteEpargne compteEpargne)
                {
                    compteEpargne.CompteId = compte.Id;
                    CreationCompteEpargne(compteEpargne);
                }
                else if(compte is ComptePayant comptePayant)
                {
                    comptePayant.CompteId = compte.Id;
                    CreationComptePayant(comptePayant);
                }
            }
            return false;
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

        public bool CreationCompteEpargne(CompteEpargne compte)
        {
            string request = "INSERT INTO compteEpargne (compte_id, taux) " +
                "OUTPUT INSERTED.ID values(@compteId, @taux)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@compteId", compte.CompteId));
            command.Parameters.Add(new SqlParameter("@taux", compte.Taux));
            Connection.Instance.Open();
            compte.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            return compte.Id > 0;
        }

        public bool CreationComptePayant(ComptePayant compte)
        {
            string request = "INSERT INTO comptePayant (compte_id, cout) " +
                "OUTPUT INSERTED.ID values(@compteId, @cout)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@compteId", compte.CompteId));
            command.Parameters.Add(new SqlParameter("@cout", compte.CoutOperation));
            Connection.Instance.Open();
            compte.Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            return compte.Id > 0;
        }

    }
}
