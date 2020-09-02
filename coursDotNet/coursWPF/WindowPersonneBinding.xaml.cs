using coursWPF.ViewModels;
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

namespace coursWPF
{
    /// <summary>
    /// Logique d'interaction pour WindowPersonneBinding.xaml
    /// </summary>
    public partial class WindowPersonneBinding : Window
    {
        ViewModelPersonne viewModel;
        public WindowPersonneBinding()
        {
           InitializeComponent();
            viewModel = new ViewModelPersonne();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(viewModel.Personne.Nom + " "+viewModel.Personne.Prenom);
            viewModel.AddPersonne();
        }
    }
}
