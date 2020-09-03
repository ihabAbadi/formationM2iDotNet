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
    /// Logique d'interaction pour OperationWindow.xaml
    /// </summary>
    public partial class OperationWindow : Window
    {
        private OperationViewModel viewModel;
        private HomeWindow homeWindow;
        public OperationWindow()
        {
            InitializeComponent();
            viewModel = new OperationViewModel();
            DataContext = viewModel;
        }

        public OperationWindow(Compte compte, bool isDepot, HomeWindow window) : this()
        {
            viewModel.Compte = compte;
            viewModel.IsDepot = isDepot;
            homeWindow = window;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            Operation operation;
            if(viewModel.IsDepot)
            {
                operation = new Operation(viewModel.Montant, viewModel.Compte.Id);
                if(viewModel.Compte.Depot(operation))
                {
                    MessageBox.Show("Dépôt Effectué");
                }
                else
                {
                    MessageBox.Show("Erreur serveur");
                }
            }
            else
            {
                operation = new Operation(viewModel.Montant * -1, viewModel.Compte.Id);
                if (viewModel.Compte.Retrait(operation))
                {
                    MessageBox.Show("Retrait Effectué");
                }
                else
                {
                    MessageBox.Show("Problème solde");
                }
            }
            (homeWindow.DataContext as HomeViewModel).ListeComptes = Sauvegarde.Instance.ChercherComptes();
            Close();
        }
    }
}
