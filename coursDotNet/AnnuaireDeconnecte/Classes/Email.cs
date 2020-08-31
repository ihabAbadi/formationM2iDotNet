using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AnnuaireDeconnecte.Classes
{
    class Email
    {
        private int id;
        private int contactId;
        private string mail;
        private static SqlCommand command;
        private static SqlDataReader reader;

        public int Id { get => id; set => id = value; }
        public int ContactId { get => contactId; set => contactId = value; }
        public string Mail { get => mail; set => mail = value; }

        public Email()
        {

        }

        public Email(string mail, int contactId)
        {
            Mail = mail;
            ContactId = contactId;
        }
        public bool Save()
        {
            //string request = "INSERT INTO email (mail, contact_id) OUTPUT INSERTED.ID" +
            //    " values(@mail, @contact_id)";
            //command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@mail", Mail));
            //command.Parameters.Add(new SqlParameter("@contact_id", ContactId));
            //Connection.Instance.Open();
            //Id = (int)command.ExecuteScalar();
            //command.Dispose();
            //Connection.Instance.Close();
            DataTable emails = Data.Instance.Tables["email"];
            DataRow row = emails.NewRow();
            row["contact_id"] = ContactId;
            row["mail"] = Mail;
            emails.Rows.Add(row);
            return (int)row["Id"] > 0;
        }

        public bool Delete()
        {
            //string request = "DELETE FROM email where id = @id";
            //command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@id", Id));
            //Connection.Instance.Open();
            //int nbRows = command.ExecuteNonQuery();
            //command.Dispose();
            //Connection.Instance.Close();
            DataTable emails = Data.Instance.Tables["email"];
            bool retour = false;
            foreach(DataRow r in emails.Rows)
            {
                if((int)r["Id"] == Id && r.RowState != DataRowState.Deleted)
                {
                    r.Delete();
                    retour = true;
                }
            }
            return retour;
        }
        public bool Update()
        {
            //string request = "UPDATE email set mail = @mail where id=@id";
            //command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@mail", Mail));
            //command.Parameters.Add(new SqlParameter("@id", Id));
            //Connection.Instance.Open();
            //int nbRows = command.ExecuteNonQuery();
            //command.Dispose();
            //Connection.Instance.Close();
            //return nbRows == 1;
            DataTable emails = Data.Instance.Tables["email"];
            bool retour = false;
            foreach (DataRow r in emails.Rows)
            {
                if ((int)r["Id"] == Id && r.RowState != DataRowState.Deleted)
                {
                    r["contact_id"] = ContactId;
                    r["mail"] = Mail;
                    retour = true;
                }
            }
            return retour;

        }

        public static List<Email> GetEmails(int contactId)
        {
            List<Email> liste = new List<Email>();
            //string request = "SELECT * FROM email where contact_id=@contact_id";
            //command = new SqlCommand(request, Connection.Instance);
            //command.Parameters.Add(new SqlParameter("@contact_id", contactId));
            //Connection.Instance.Open();
            //reader = command.ExecuteReader();
            //while(reader.Read())
            //{
            //    Email e = new Email(reader.GetString(1), reader.GetInt32(2))
            //    {
            //        Id = reader.GetInt32(0)
            //    };
            //    liste.Add(e);
            //}
            //reader.Close();
            //command.Dispose();
            //Connection.Instance.Close();
            DataTable emails = Data.Instance.Tables["email"];
            foreach (DataRow r in emails.Rows)
            {
                if ((int)r["contact_id"] == contactId && r.RowState != DataRowState.Deleted)
                {
                    Email e = new Email(r["mail"].ToString(), contactId)
                    {
                        Id = (int)r["Id"]
                    };
                    liste.Add(e);
                }
            }
            return liste;
        }

        public override string ToString()
        {
            return $"Id : {Id}, Mail : {Mail}";
        }
    }
}
