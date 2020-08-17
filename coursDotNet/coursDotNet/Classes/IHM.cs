using System;
using System.Collections.Generic;
using System.Text;

namespace coursDotNet.Classes
{
    class IHM
    {
        private Album album;
        public void Start()
        {
            Console.WriteLine("---Bienvenue sur le gestionnaire d'album---");
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        CreationAlbum();
                        GestionTitre();
                        break;
                }
            } while (choix != "0");
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1-- Créer un album");
            Console.WriteLine("0-- Quitter");
        }

        private void CreationAlbum()
        {
            Console.Write("Le nom de l'album : ");
            string n = Console.ReadLine();
            Console.Write("L'auteur de l'album : ");
            string a = Console.ReadLine();
            Console.Write("Le nombre de titre : ");
            int nb = Convert.ToInt32(Console.ReadLine());
            album = new Album(nb, n, a);
        }

        private void GestionTitre()
        {
            Console.Clear();
            string choix;
            do
            {
                MenuTitre();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        AjouterTitre();
                        break;
                    case "2":
                        ListeTitres();
                        break;
                    case "3":
                        RechercherTitre();
                        break;
                }
            } while (choix != "0");
        }
        private void MenuTitre()
        {
            Console.WriteLine("1--Ajouter un titre : ");
            Console.WriteLine("2--Liste des titres : ");
            Console.WriteLine("3--Rechercher un titre : ");
            Console.WriteLine("0--Revenir au menu principal : ");
        }

        private void AjouterTitre()
        {

        }

        private void ListeTitres()
        {

        }

        private void RechercherTitre()
        {

        }
    }
}
