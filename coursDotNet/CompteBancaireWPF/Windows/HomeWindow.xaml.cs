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
    /// Logique d'interaction pour HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private HomeViewModel viewModel;
        public HomeWindow()
        {
            InitializeComponent();
            viewModel = new HomeViewModel();
            DataContext = viewModel;
        }

        private void Ajouter_Compte_Click(object sender, RoutedEventArgs e)
        {
            if (Sauvegarde.Instance.CreationCompte(viewModel.Compte))
            {
                viewModel.ListeComptes.Add(viewModel.Compte);
                MessageBox.Show("Compte crée avec le numéro : "+viewModel.Compte.Numero);
                viewModel.Compte = new Compte();
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            viewModel.ListeComptes = Sauvegarde.Instance.ChercherComptes(viewModel.Search);
        }
    }
}
