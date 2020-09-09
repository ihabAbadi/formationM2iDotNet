using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class IHM
    {
        private List<Compte> listeComptes;
        private int numeroCompte;
        public IHM()
        {
            listeComptes = new List<Compte>();
        }

        public void Start()
        {
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                switch(choix)
                {
                    case "1":
                        ActionCreationCompte();
                        break;
                    case "2":
                        ActionDepot();
                        break;
                    case "3":
                        ActionRetrait();
                        break;
                    case "4":
                        ActionAfficherOperationsEtSolde();
                        break;
                    case "5":
                        ActionCalculeInteretCompteEpargne();
                        break;
                    case "0":
                        //Quitter la console
                        Environment.Exit(0);
                        break;
                }
                
            } while (choix != "0");
        }

        private void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("-----Gestion compte-----");
            Console.WriteLine("1--Créer un compte");
            Console.WriteLine("2--Effectuer un dépot");
            Console.WriteLine("3--Effectuer un retrait");
            Console.WriteLine("4--Afficher un compte");
            Console.WriteLine("5--Calcule Interet compte epargne");
            Console.WriteLine("0--Quitter");
        }

        private void MenuCreationCompte()
        {
            Console.WriteLine("1--Compte standard");
            Console.WriteLine("2--Compte epargne");
            Console.WriteLine("3--Compte payant");
        }

        private void ActionCreationCompte()
        {
            Console.Clear();
            Console.WriteLine("---Information du client");
            Console.Write("Merci de saisir le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Merci de saisir le prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Merci de saisir le téléphone : ");
            string telephone = Console.ReadLine();
            Client client = new Client(nom, prenom, telephone);
            Console.Write("Solde initial : ");
            string chaineSolde = Console.ReadLine();
            decimal solde = (chaineSolde == "") ? 0 : Convert.ToDecimal(chaineSolde);
            Console.WriteLine("---Type de compte : ");
            MenuCreationCompte();
            Compte compte = null;
            string choix = Console.ReadLine();
            switch(choix)
            {
                case "1":
                    compte = new Compte(client,Sauvegarde.Instance, solde);
                    break;
                case "2":
                    Console.Write("Merci de saisir le taux : ");
                    int taux = Convert.ToInt32(Console.ReadLine());
                    compte = new CompteEpargne(client, taux, solde);
                    break;
                case "3":
                    Console.WriteLine("Merci de saisir le cout de chaque opération : ");
                    int cout = Convert.ToInt32(Console.ReadLine());
                    compte = new ComptePayant(client, cout, solde);
                    break;
            }
            if(compte != null)
            {
                //listeComptes.Add(compte);
                Sauvegarde.Instance.CreationCompte(compte);
                Console.WriteLine("Compte crée avec le numéro : " + compte.Numero);
            }
            else
            {
                Console.WriteLine("Erreur création compte");
            }
            Console.Read();
        }

        private void ActionDepot()
        {
            Console.Clear();
            Compte compte = ActionRechercheCompte();
            if(compte != null)
            {
                Console.Write("Le montant du dépot : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                Operation o = new Operation(montant, compte.Id);
                if (compte.Depot(o))
                {
                    Console.WriteLine("Dépot éfféctué");
                    Console.WriteLine("Le nouveau solde : " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur dépot");
                }
            }
            else
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            Console.Read();
        }

        private void ActionRetrait()
        {
            Console.Clear();
            Compte compte = ActionRechercheCompte();
            if (compte != null)
            {
                Console.Write("Le montant du retrait : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                Operation o = new Operation(montant*-1, compte.Id);
                if (compte.Retrait(o))
                {
                    Console.WriteLine("Retrait éfféctué");
                    Console.WriteLine("Le nouveau solde : " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur retrait");
                }
            }
            else
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            Console.Read();
        }
        private void ActionAfficherOperationsEtSolde()
        {
            Console.Clear();
            Compte compte = ActionRechercheCompte();
            if (compte != null)
            {
                compte.Operations = Sauvegarde.Instance.getOperations(compte.Id);
                Console.WriteLine(compte);
            }
            else
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            Console.Read();
        }

        private void ActionCalculeInteretCompteEpargne()
        {
            Console.Clear();
            Compte compte = ActionRechercheCompte();
            if(compte != null)
            {
                if(compte is CompteEpargne compteEpargne)
                {
                    compteEpargne.UpdateSolde();
                    Console.WriteLine("Le nouveau solde est de : " + compteEpargne.Solde);
                }
                else
                {
                    Console.WriteLine("Ce compte n'est pas un compte epargne");
                }
            }
            else
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            Console.Read();
        }

        private Compte ActionRechercheCompte()
        {
            Compte compte = null;
            Console.Write("Merci de saisir le numéro de compte : ");
            string numero = Console.ReadLine();
            //foreach(Compte c in listeComptes)
            //{
            //    if(c.Numero == numero)
            //    {
            //        compte = c;
            //        break;
            //    }
            //}
            compte = Sauvegarde.Instance.ChercherCompte(numero);
            return compte;
        }
    }
}
