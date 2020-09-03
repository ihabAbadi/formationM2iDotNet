using CompteBancaireWPF.Classes;
using CompteBancaireWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CompteBancaireWPF.Windows
{
    /// <summary>
    /// Logique d'interaction pour OperationsWindow.xaml
    /// </summary>
    public partial class OperationsWindow : Window
    {
        private OperationsViewModel viewModel;
        public OperationsWindow()
        {
            InitializeComponent();
            viewModel = new OperationsViewModel();
            DataContext = viewModel;
        }

        public OperationsWindow(Compte compte) : this()
        {
            compte.Operations = Sauvegarde.Instance.getOperations(compte.Id);
            viewModel.Compte = compte;
        }
    }
}
