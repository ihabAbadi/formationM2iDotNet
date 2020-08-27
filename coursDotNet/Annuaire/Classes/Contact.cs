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
        private static SqlCommand command;
        private static SqlDataReader reader;
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
            string request = "UPDATE contact set nom=@nom, prenom=@prenom, telephone=@telephone" +
                " where id=@id";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@nom", Nom));
            command.Parameters.Add(new SqlParameter("@prenom", Prenom));
            command.Parameters.Add(new SqlParameter("@telephone", Telephone));
            command.Parameters.Add(new SqlParameter("@id", Id));
            Connection.Instance.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            Connection.Instance.Close();
            return nbRow == 1;
        }
        public bool Delete()
        {
            string request = "DELETE FROM contact where id=@id";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", Id));
            Connection.Instance.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            Connection.Instance.Close();
            if(nbRow == 1)
            {
                Emails.ForEach(e => e.Delete());
                //foreach(Email e in Emails)
                //{
                //    e.Delete();
                //}
            }
            return nbRow == 1;
        }

        public static List<Contact> GetContacts(string telephone= null)
        {
            List<Contact> contacts = new List<Contact>();
            string request = "SELECT * FROM contact";
            if(telephone != null)
            {
                request += " where telephone like @telephone";
            }
            command = new SqlCommand(request, Connection.Instance);
            if(telephone != null)
            {
                command.Parameters.Add(new SqlParameter("@telephone", telephone + "%"));
            }
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Contact c = new Contact(reader.GetString(1), reader.GetString(2), reader.GetString(3))
                {
                    Id = reader.GetInt32(0)
                };
                contacts.Add(c);
                //contacts.Add(new Contact(reader.GetString(1), reader.GetString(2), reader.GetString(3)) { Id = reader.GetInt32(0) });
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            contacts.ForEach(c =>
            {
                c.Emails = Email.GetEmails(c.Id);
            });
            return contacts;
        }

        public static Contact GetContactById(int id)
        {
            Contact contact = null;
            string request = "SELECT * FROM contact where id=@id";
            command = new SqlCommand(request, Connection.Instance);
            command.Parameters.Add(new SqlParameter("@id", id));
            Connection.Instance.Open();
            reader = command.ExecuteReader();
            if(reader.Read())
            {
                contact = new Contact(reader.GetString(1), reader.GetString(2), reader.GetString(3))
                {
                    Id = reader.GetInt32(0)
                };
            }
            reader.Close();
            command.Dispose();
            Connection.Instance.Close();
            if (contact != null)
                contact.Emails = Email.GetEmails(id);
            return contact;
        }

        public override string ToString()
        {
            string retour = "";
            retour += $"Id : {Id}, Nom : {Nom}, Prénom : {Prenom}, Téléphone : {Telephone}\n";
            retour += "Emails : \n";
            Emails.ForEach((e) =>
            {
                retour += $"Id : {e.Id}, Mail : {e.Mail}\n";
            });
            return retour;
        }
    }
}
