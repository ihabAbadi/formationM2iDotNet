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
    /// Logique d'interaction pour WindowPersonne.xaml
    /// </summary>
    public partial class WindowPersonne : Window
    {
        private List<Personne> listePersonnes;
        public WindowPersonne()
        {
            InitializeComponent();
            listePersonnes = new List<Personne>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //List<Personne> tmpPersonnes = new List<Personne>();
            //tmpPersonnes.AddRange(listePersonnes);
            ListeBoxPersonne.ItemsSource = null;
            ListeViewPersonne.ItemsSource = null;
            Personne p = new Personne
            {
                Nom = TextBoxNom.Text,
                Prenom = TextBoxPrenom.Text
            };
            //tmpPersonnes.Add(p);
            listePersonnes.Add(p);
            ListeBoxPersonne.ItemsSource = listePersonnes;
            ListeViewPersonne.ItemsSource = listePersonnes;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(ListeBoxPersonne.SelectedItem is Personne p)
            {
                ResultPersonne.Text = p.ToString();
                DetailPersonneWindow window = new DetailPersonneWindow(p);
                window.Show();
            }
        }
    }
}
