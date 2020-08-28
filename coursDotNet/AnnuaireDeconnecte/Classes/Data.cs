using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AnnuaireDeconnecte.Classes
{
    class Data
    {
        private static DataSet _instance;
        private static SqlDataAdapter contactAdapter;
        public static DataSet Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DataSet();
                return _instance;
            }
        }
        
        private Data()
        {
            
        }
        public static void Init()
        {
            contactAdapter = new SqlDataAdapter("SELECT * from contact", Connection.Instance);
            string insertRequest = "INSERT INTO contact(nom, prenom, telephone)" +
                " values (@nom, @prenom, @telephone)";
            contactAdapter.InsertCommand = new SqlCommand(insertRequest, Connection.Instance);
            contactAdapter.InsertCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nom");
            contactAdapter.InsertCommand.Parameters.Add("@prenom", SqlDbType.VarChar, 50, "Prenom");
            contactAdapter.InsertCommand.Parameters.Add("@telephone", SqlDbType.VarChar, 10, "Telephone");
            string updateRequest = "UPDATE contact set nom=@nom, prenom=@prenom, telephone=@telephone where id=@id";
            contactAdapter.UpdateCommand = new SqlCommand(updateRequest, Connection.Instance);
            contactAdapter.UpdateCommand.Parameters.Add("@nom", SqlDbType.VarChar, 50, "Nom");
            contactAdapter.UpdateCommand.Parameters.Add("@prenom", SqlDbType.VarChar, 50, "Prenom");
            contactAdapter.UpdateCommand.Parameters.Add("@telephone", SqlDbType.VarChar, 10, "Telephone");
            contactAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            string deleteRequest = "DELETE from contact where id=@id";
            contactAdapter.DeleteCommand = new SqlCommand(deleteRequest, Connection.Instance);
            contactAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            Connection.Instance.Open();
            contactAdapter.Fill(Instance, "contact");
            Connection.Instance.Close();
        }

        public static void Update()
        {
            contactAdapter.Update(Instance.Tables["contact"]);
        }
    }
}
