using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    partial class IHM
    {
        private Forum forum;
        private Abonne utilisateur;

        public void Start()
        {
            CreationForum();
            while(true)
            {
                ActionConnexion();
            }
        }

        private void CreationForum()
        {
            Console.WriteLine("---Création du Forum---");
            Console.Write("Nom du forum : ");
            string nom = Console.ReadLine();
            forum = new Forum(nom, CreationModerateur());
            Console.ReadLine();
        }

        private Moderateur CreationModerateur()
        {
            Console.WriteLine("---Création du modérateur du Forum---");
            Console.Write("Nom du modérateur : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom du modérateur : ");
            string prenom = Console.ReadLine();
            Console.Write("Age du modérateur : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Moderateur m = new Moderateur(nom, prenom, age);
            return m;
        }

        
        //private void MenuTypeCompte()
        //{
        //    Console.WriteLine("1--- vous êtes modérateur");
        //    Console.WriteLine("2--- vous êtes abonné");
        //}
        private void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("1--- Créer une nouvelle");
            Console.WriteLine("2--- Publier une nouvelle");
            Console.WriteLine("3--- Répondre à une nouvelle");
            Console.WriteLine("4--- Afficher les nouvelles");
        }

        private void MenuModerateur()
        {
            MenuPrincipal();
            Console.WriteLine("5--- Ajouter un abonné");
            Console.WriteLine("6--- Supprimer une nouvelle");
            Console.WriteLine("7--- Bannir un abonné");
            Console.WriteLine("8--- Afficher les abonnés");
        }
    }
}
