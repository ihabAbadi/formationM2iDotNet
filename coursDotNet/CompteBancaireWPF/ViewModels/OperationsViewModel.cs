using CompteBancaireWPF.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaireWPF.ViewModels
{
    public class OperationsViewModel
    {
        private Compte compte;

        public Compte Compte { get => compte; set => compte = value; }
    }
}
