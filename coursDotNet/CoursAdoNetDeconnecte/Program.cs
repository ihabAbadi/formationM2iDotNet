using System;
using System.Data;
using System.Data.SqlClient;

namespace CoursAdoNetDeconnecte
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
            //lien entre base de données et dataSet
            string request = "SELECT * FROM personne";
            SqlDataAdapter adapter = new SqlDataAdapter(request, connection);
            //Méthode d'insertion des données
            adapter.InsertCommand = new SqlCommand("INSERT INTO personne(Nom, Prenom) values (@Nom, @Prenom)",connection);
            adapter.InsertCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50, "Nom");
            adapter.InsertCommand.Parameters.Add("@Prenom", SqlDbType.VarChar, 50, "Prenom");
            //Méthode d'update des données
            adapter.UpdateCommand = new SqlCommand("UPDATE personne set Nom=@Nom, Prenom=@Prenom where Id=@Id",connection);
            adapter.UpdateCommand.Parameters.Add("@Nom", SqlDbType.VarChar, 50, "Nom");
            adapter.UpdateCommand.Parameters.Add("@Prenom", SqlDbType.VarChar, 50, "Prenom");
            adapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 11, "Id");
            //Méthode de delete des données
            adapter.DeleteCommand = new SqlCommand("DELETE from personne where Id=@Id", connection);
            adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 11, "Id");
            //pour stocker les données dans notre application, on utilise un objet de type DataSet
            DataSet data = new DataSet();
            connection.Open();
            adapter.Fill(data, "personne");
            connection.Close();
            //Lire les données à partir du dataSet
            DataTable personnes = data.Tables["personne"];
            
            foreach(DataRow row in personnes.Rows)
            {
                Console.WriteLine("Id : " + row["Id"] + "Nom : " + row["Nom"] + " Prénom : " + row["Prenom"]);
            }

            //Ajouter des données dans le dataSet
            //DataRow newLine = personnes.NewRow();
            //newLine["Nom"] = "New first name ";
            //newLine["Prenom"] = "New last name ";
            //personnes.Rows.Add(newLine);
            //newLine = personnes.NewRow();
            //newLine["Nom"] = "next first name ";
            //newLine["Prenom"] = "next last name ";
            //personnes.Rows.Add(newLine);


            //Modifier la ligne avec id = 2
            //foreach (DataRow row in personnes.Rows)
            //{
            //    if((int)row["Id"] == 2)
            //    {
            //        row["Nom"] = "Update First Name at 2";
            //        row["Prenom"] = "Update Last Name at 2";
            //    }
            //} <=> 
            //DataRow[] rows = personnes.Select("Id = 2");
            //foreach(DataRow r in rows)
            //{
            //    r["Nom"] = "Update First Name at 2";
            //    r["Prenom"] = "Update Last Name at 2";
            //}


            //Supprimer la ligne avec Nom titi
            DataRow[] rows = personnes.Select("Nom = 'titi'");
            foreach (DataRow r in rows)
            {
                r.Delete();
            }

            //Mettre à jour la base de données
            int nbRow = adapter.Update(personnes);
            Console.WriteLine("----Après ajout----");
            foreach (DataRow row in personnes.Rows)
            {
                Console.WriteLine("Id : " + row["Id"] + "Nom : " + row["Nom"] + " Prénom : " + row["Prenom"]);
            }
        }
    }
}
