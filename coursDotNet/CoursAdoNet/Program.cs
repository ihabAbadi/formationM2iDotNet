using System;
using System.Data.SqlClient;

namespace CoursAdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Merci de saisir votre nom : ");
            //string nom = Console.ReadLine();
            //Console.Write("Merci de saisir votr prénom : ");
            //string prenom = Console.ReadLine();
            //Etablir une connexion avec une base de données de type sql server
            //On utilise un objet de type SqlConnection
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
            //string request = "INSERT INTO personne (Nom, Prenom) OUTPUT INSERTED.ID values(@nom, @prenom)";
            string request = "select * from personne";
            SqlCommand command = new SqlCommand(request, connection);
            //command.Parameters.Add(new SqlParameter("@nom", nom));
            //command.Parameters.Add(new SqlParameter("@prenom", prenom));
            //Ouvrir une connexion
            connection.Open();
            //Execution de la commande
            //Premier type d'execution => execution sans retour
            //if(command.ExecuteNonQuery() > 0)
            //{
            //    Console.WriteLine("personne ajoutée");
            //}
            //Deuxième type d'execution => execution avec un seul retour

            //int id = (int)command.ExecuteScalar();
            //if(id > 0)
            //{
            //    Console.WriteLine("Personne ajoutée avec l'id " + id);
            //}

            //3ème type d'execution => execution avec plusieurs retours, lecture de données par exemple
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine("Id : " + reader.GetInt32(0) + ", Nom : " + reader.GetString(1)+", Prénom : " + reader.GetString(2));
            }
            reader.Close();
            command.Dispose();
            //Ferme la connexion
            connection.Close();
        }
    }
}
