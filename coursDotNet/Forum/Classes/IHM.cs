using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    class IHM
    {
        private Forum forum;
        private Abonne utilisateur;

        public void Start()
        {
            CreationForum();
            ActionConnexion();
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

        private void ActionConnexion()
        {
            Console.Clear();
            Console.Write("Votre id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if(forum.Moderateur.Id == id)
            {
                ActionModerateur();
            }
            else
            {
                utilisateur = forum.GetAbonneById(id);
                if(utilisateur == null)
                {
                    Console.WriteLine("Aucun utilisateur avec cet id");
                }
                else if(utilisateur.Statut == "actif")
                {
                    ActionAbonne();
                }
                else
                {
                    Console.WriteLine("Vous êtes banni");
                }
            }
        }

        private void ActionModerateur()
        {
            Console.WriteLine("---Vous êtes connecté en tant que modérateur---");
            string choix;
            do
            {
                MenuModerateur();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        ActionCreationNouvelle(forum.Moderateur);
                        break;
                    case "2":
                        ActionPublierNouvelle(forum.Moderateur);
                        break;
                    case "3":
                        ActionRepondreNouvelle(forum.Moderateur);
                        break;
                    case "4":
                        ActionAfficherNouvelle();
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;
                    case "8":
                        break;
                }
            } while (choix != "0");
        }

        private void ActionAbonne()
        {
            Console.WriteLine("---Vous êtes connecté en tant que abonné---");
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        ActionCreationNouvelle(utilisateur);
                        break;
                    case "2":
                        ActionPublierNouvelle(utilisateur);
                        break;
                    case "3":
                        ActionRepondreNouvelle(utilisateur);
                        break;
                    case "4":
                        ActionAfficherNouvelle();
                        break;                  
                }
            } while (choix != "0");
        }

        private void ActionCreationNouvelle(Abonne abonne)
        {
            Console.Write("Sujet de la nouvelle : ");
            string sujet = Console.ReadLine();
            Console.Write("Contenu de la nouvelle : ");
            string contenu = Console.ReadLine();
            Nouvelle nouvelle = abonne.CreerNouvelle(sujet, contenu);
            Console.WriteLine("---Votre nouvelle a été créée");
            Console.WriteLine(nouvelle);
            Console.ReadLine();
        }

        private void ActionPublierNouvelle(Abonne abonne)
        {
            ActionAfficherNouvelleAbonne(abonne);
            Console.Write("Id de la nouvelle à publier : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Nouvelle nouvelleApublie = abonne.GetNouvelleById(id);
            if(nouvelleApublie == null)
            {
                Console.WriteLine("Aucune nouvelle avec cet id");
            }
            else if(nouvelleApublie.Statut=="Publié")
            {
                Console.WriteLine("Nouvelle déjà publiée");
            }
            else
            {
                abonne.PublierNouvelle(nouvelleApublie, forum);
                Console.WriteLine("Nouvelle publiée");
            }
            Console.ReadLine();
        }

        private void ActionRepondreNouvelle(Abonne abonne)
        {
            ActionAfficherNouvelle();
            Console.Write("Id nouvelle à qui on souhaite répondre : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Nouvelle nouvelle = forum.GetNouvelleById(id);
            if(nouvelle == null)
            {
                Console.WriteLine("Aucune nouvelle avec cet id");
            }
            else
            {
                Console.WriteLine("Contenu de la réponse : ");
                string contenu = Console.ReadLine();
                abonne.RepondreNouvelle(nouvelle, contenu);
            }
            Console.ReadLine();
        }

        private void ActionAfficherNouvelle()
        {
            foreach(Nouvelle n in forum.Nouvelles)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        } 

        private void ActionAfficherNouvelleAbonne(Abonne abonne, string statut = "Non publiée")
        {
            Console.WriteLine("---Vos nouvelles---");
            foreach(Nouvelle n in abonne.Nouvelles)
            {
                if(n.Statut == statut)
                    Console.WriteLine(n);
            }
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
