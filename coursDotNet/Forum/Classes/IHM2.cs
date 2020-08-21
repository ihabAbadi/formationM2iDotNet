using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Classes
{
    partial class IHM
    {
        private void ActionConnexion()
        {
            Console.Clear();
            Console.Write("Votre id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (forum.Moderateur.Id == id)
            {
                ActionModerateur();
            }
            else
            {
                utilisateur = forum.GetAbonneById(id);
                if (utilisateur == null)
                {
                    Console.WriteLine("Aucun utilisateur avec cet id");
                }
                else if (utilisateur.Statut == "actif")
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
                switch (choix)
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
                        ActionAjouterAbonne();
                        break;
                    case "6":
                        ActionSupprimerNouvelle();
                        break;
                    case "7":
                        ActionBannirAbonne();
                        break;
                    case "8":
                        ActionListeAbonnes();
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
                switch (choix)
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
            if (nouvelleApublie == null)
            {
                Console.WriteLine("Aucune nouvelle avec cet id");
            }
            else if (nouvelleApublie.Statut == StatutNouvelle.Publie)
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
            if (nouvelle == null)
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
            foreach (Nouvelle n in forum.Nouvelles)
            {
                Console.WriteLine(n);
            }
            Console.ReadLine();
        }

        private void ActionAjouterAbonne()
        {
            Console.Write("Le nom de l'abonné : ");
            string nom = Console.ReadLine();
            Console.Write("Le prénom de l'abonné : ");
            string prenom = Console.ReadLine();
            Console.Write("L'age de l'abonné : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Abonne a = forum.Moderateur.AjouterAbonne(forum, nom, prenom, age);
            Console.WriteLine("Abonné crée");
            Console.WriteLine(a);
            Console.WriteLine("Continuer...");
            Console.ReadLine();
        }

        private void ActionSupprimerNouvelle()
        {
            ActionAfficherNouvelle();
            Console.Write("L'id de la nouvelle à supprimer : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Nouvelle nouvelle = forum.GetNouvelleById(id);
            if (nouvelle == null)
            {
                Console.WriteLine("Aucune nouvelle avec cet id");
            }
            else
            {
                forum.Moderateur.SupprimerNouvelle(forum, nouvelle);
                Console.WriteLine("Nouvelle supprimée");
            }
            Console.WriteLine("Continuer...");
            Console.ReadLine();
        }

        private void ActionBannirAbonne()
        {
            ActionListeAbonnes();
            Console.Write("L'id de l'abonné à bannir : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Abonne abonne = forum.GetAbonneById(id);
            if (abonne == null)
            {
                Console.WriteLine("Aucun abonné avec cet id");
            }
            else
            {
                forum.Moderateur.BannirAbonne(abonne);
                Console.WriteLine("Abonné banni");
            }
            Console.WriteLine("Continuer...");
            Console.ReadLine();
        }
        private void ActionListeAbonnes()
        {
            Console.WriteLine("-----Liste des abonnés-----");
            foreach (Abonne a in forum.Abonnes)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine("Continuer....");
            Console.ReadLine();
        }
        private void ActionAfficherNouvelleAbonne(Abonne abonne, StatutNouvelle statut = StatutNouvelle.NonPublie)
        {
            Console.WriteLine("---Vos nouvelles---");
            foreach (Nouvelle n in abonne.Nouvelles)
            {
                if (n.Statut == statut)
                    Console.WriteLine(n);
            }
        }

    }
}
