﻿using System;
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
        private static SqlDataAdapter emailAdapter;
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
            Instance.Tables["contact"].Columns["Id"].AutoIncrement = true;
            Instance.Tables["contact"].Columns["Id"].AutoIncrementSeed = Instance.Tables["contact"].Rows.Count > 0 ? (int)Instance.Tables["contact"].Rows[Instance.Tables["contact"].Rows.Count - 1]["id"] + 1 : 1;
            Instance.Tables["contact"].Columns["Id"].AutoIncrementStep = 1;
            Connection.Instance.Close();
        }

        public static void InitMail()
        {
            emailAdapter = new SqlDataAdapter("SELECT * from email", Connection.Instance);
            string insertRequest = "INSERT INTO email(mail, contact_id)" +
                " values (@mail, @contact_id)";
            emailAdapter.InsertCommand = new SqlCommand(insertRequest, Connection.Instance);
            emailAdapter.InsertCommand.Parameters.Add("@mail", SqlDbType.VarChar, 100, "mail");
            emailAdapter.InsertCommand.Parameters.Add("@contact_id", SqlDbType.Int, 11, "contact_id");
            string updateRequest = "UPDATE email set mail=@mail, contact_id=@contact_id where id=@id";
            emailAdapter.UpdateCommand = new SqlCommand(updateRequest, Connection.Instance);
            emailAdapter.UpdateCommand.Parameters.Add("@mail", SqlDbType.VarChar, 100, "mail");
            emailAdapter.UpdateCommand.Parameters.Add("@contact_id", SqlDbType.Int, 11, "contact_id");
            contactAdapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            string deleteRequest = "DELETE from email where id=@id";
            emailAdapter.DeleteCommand = new SqlCommand(deleteRequest, Connection.Instance);
            emailAdapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 11, "Id");
            Connection.Instance.Open();
            emailAdapter.Fill(Instance, "email");
            Instance.Tables["email"].Columns["Id"].AutoIncrement = true;
            Instance.Tables["email"].Columns["Id"].AutoIncrementStep = 1;
            Instance.Tables["email"].Columns["Id"].AutoIncrementSeed = Instance.Tables["email"].Rows.Count > 0 ? (int)Instance.Tables["email"].Rows[Instance.Tables["email"].Rows.Count - 1]["id"] + 1 : 1;
            Connection.Instance.Close();
        }

        public static void Update()
        {
            contactAdapter.Update(Instance.Tables["contact"]);
            emailAdapter.Update(Instance.Tables["email"]);
        }
    }
}
