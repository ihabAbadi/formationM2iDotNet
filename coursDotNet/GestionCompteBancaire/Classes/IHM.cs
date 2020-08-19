using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCompteBancaire.Classes
{
    class IHM
    {
        private List<Compte> listeComptes;

        public IHM()
        {
            listeComptes = new List<Compte>();
        }

        public void Start()
        {

        }

        private void MenuPrincipal()
        {

        }

        private void MenuCreationCompte()
        {

        }

        private void ActionCreationCompte()
        {

        }

        private void ActionDepot()
        {

        }

        private void ActionRetrait()
        {

        }
        private void AfficherOperationsEtSolde()
        {

        }

        private Compte ActionRechercheCompte()
        {
            Compte compte = null;
            Console.Write("Merci de saisir le numéro de compte : ");
            int numero = Convert.ToInt32(Console.ReadLine());
            foreach(Compte c in listeComptes)
            {
                if(c.Numero == numero)
                {
                    compte = c;
                    break;
                }
            }
            return compte;
        }
    }
}
