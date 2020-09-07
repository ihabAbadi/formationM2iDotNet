using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecole.Tools
{
    class Connection
    {
        private static SqlConnection _instance;
        private static Mutex m = new Mutex(); 
        public static SqlConnection Instance
        {
            get
            {
                m.WaitOne();
                if (_instance == null)
                {
                    _instance = new SqlConnection(@"Data Source=(LocalDb)\coursM2I;Integrated Security=True");
                    //CreateTable();
                }
                m.ReleaseMutex();
                return _instance;
            }
        }

        private Connection()
        {
           
        }

        private static void CreateTable()
        {
            //Table Personne (id, nom, prenom, email, telephone, adresse, code_postal, ville)
            string request = "if not exists(SELECT * FROM Personne) " +
                "CREATE TABLE [Personne] (" +
                "Id int PRIMARY KEY IDENTITY," +
                "Nom varchar(50) NOT NULL," +
                "Prenom varchar(50) NOT NULL," +
                "Email varchar(50) NOT NULL," +
                "Telephone varchar(10) NOT NULL," +
                "Adresse varchar(150) NOT NULL," +
                "Code_postal varchar(5) NOT NULL," +
                "Ville varchar(50) NOT NULL)";
            SqlCommand command = new SqlCommand(request, Instance);
            Instance.Open();
            command.ExecuteNonQuery();
            command.Dispose();
            request = "if not exists(SELECT * FROM Matiere) " +
                "CREATE TABLE Matiere (" +
                "Id int PRIMARY KEY IDENTITY," +
                "Nom varchar(50) NOT NULL); INSERT INTO Matiere (nom) values('Physique'), ('Maths'), ('Français')";
            command = new SqlCommand(request, Instance);
            command.ExecuteNonQuery();
            command.Dispose();
            request = "if not exists(SELECT * FROM classe) " +
                "CREATE TABLE classe (" +
                "Id int PRIMARY KEY IDENTITY," +
                "Nom varchar(50) NOT NULL); INSERT INTO classe (nom) values('premiere'), ('seconde'), ('bac')";
            command = new SqlCommand(request, Instance);
            command.ExecuteNonQuery();
            command.Dispose();
            request = "if not exists(SELECT * FROM etudiant) " +
                "CREATE TABLE etudiant (" +
                "Id int PRIMARY KEY IDENTITY," +
                "personne_id int NOT NULL," +
                "classe_id int NOT NULL);";
            command = new SqlCommand(request, Instance);
            command.ExecuteNonQuery();
            command.Dispose();
            request = "if not exists(SELECT * FROM prof) " +
                "CREATE TABLE prof (" +
                "Id int PRIMARY KEY IDENTITY," +
                "personne_id int NOT NULL," +
                "matiere_id int NOT NULL);";
            command = new SqlCommand(request, Instance);
            command.ExecuteNonQuery();
            command.Dispose();
        }
    }
}
