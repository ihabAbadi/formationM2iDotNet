using CompteBancaireWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CompteBancaireWPF.ViewModels
{
    public class OperationViewModel
    {
        private decimal montant;
        private bool isDepot;
        private Compte compte;

        public decimal Montant { get => montant; set => montant = value; }
        public bool IsDepot { get => isDepot; set => isDepot = value; }

        public Visibility VisiblityDepot { get => IsDepot ? Visibility.Visible : Visibility.Hidden; }
        public Visibility VisiblityRetrait { get => !IsDepot ? Visibility.Visible : Visibility.Hidden; }
        public Compte Compte { get => compte; set => compte = value; }

    }
}
