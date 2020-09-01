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
    /// Logique d'interaction pour DetailPersonneWindow.xaml
    /// </summary>
    public partial class DetailPersonneWindow : Window
    {
        public DetailPersonneWindow()
        {
            InitializeComponent();
        }

        public DetailPersonneWindow(Personne p) : this()
        {
            ResultPersonne.Text = p.ToString();
        }
    }
}
