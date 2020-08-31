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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace coursWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //definition des Rows et des Columns
            grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });

            grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100) });
            grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Auto) });


            //Création du bouton
            Button b1 = new Button
            {
                Content = "First Button",
                FontSize = 20,
                //Background = Brushes.Red
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#cd2127"))
            };
            //Ajout du bouton dans notre grille
            grille.Children.Add(b1);

            //Placer le bouton dans la col N°3
            Grid.SetColumn(b1, 2);
            //Placer le bouton dans la ligne N°2
            Grid.SetRow(b1, 1);

            Button b2 = new Button
            {
                Content = "Second button"
            };

            grille.Children.Add(b2);
            Grid.SetColumn(b2, 3);
            Grid.SetRow(b2, 3);
            Label l = new Label
            {
                Content = "Contenu label"
            };
            grille.Children.Add(l);
            Grid.SetColumn(l, 2);
            Grid.SetRow(l, 0);
        }
    }
}
