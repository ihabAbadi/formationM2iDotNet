using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Annuaire.Classes
{
    class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private List<Email> emails;
        private SqlCommand command;
        private SqlDataReader reader;
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Email> Emails { get => emails; set => emails = value; }

        public Contact(string n, string p, string t)
        {
            Nom = n;
            Prenom = p;
            Telephone = t;
            Emails = new List<Email>();
        }
        public bool Save()
        {
            string request = "INSERT INTO contact (nom, prenom, telephone) OUTPUT INSERTED.ID" +
                " values(@nom, @prenom, @telephone)";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            Connection.Instance.Open();
            Id = (int)command.ExecuteScalar();
            command.Dispose();
            Connection.Instance.Close();
            bool retour = Id > 0;
            if(retour)
            {
                Emails.ForEach(e => {
                    e.ContactId = Id;
                    //if(!e.Save())
                    //{
                    //    retour = false;
                    //}
                    e.Save();
                });
            }
            return retour ;
        }

        public bool Update()
        {
            return false;
        }
        public bool Delete()
        {
            return false;
        }

        public static List<Contact> GetContacts(string telephone)
        {
            return null;
        }
    }
}
