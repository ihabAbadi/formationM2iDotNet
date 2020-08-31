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
    /// Logique d'interaction pour Calculatrice.xaml
    /// </summary>
    public partial class Calculatrice : Window
    {
        private string[] tab = new string[] { "C", "+/-", "%", "/", "7", "8", "9", "X", "4", "5", "6", "-", "1", "2", "3", "+", "0", ",", "=" };
        public Calculatrice()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            CreateRowsAndColumns();
            CreateLabel();
            CreateButtons();
        }

        private void CreateRowsAndColumns()
        {
            for(int i=1; i<=6; i++)
            {
                grille.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                if (i <= 4)
                    grille.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
        }

        private void CreateLabel()
        {
            Label l = new Label()
            {
                Content = "0",
                Foreground = Brushes.White,
                Background = Brushes.Black,
                HorizontalContentAlignment = HorizontalAlignment.Right,
                VerticalContentAlignment = VerticalAlignment.Center,
                FontSize = 30
            };
            grille.Children.Add(l);
            Grid.SetColumn(l, 0);
            Grid.SetRow(l, 0);
            Grid.SetColumnSpan(l, 4);
        }

        private void CreateButtons()
        {
            int k = 0;
            for(int i=1; i<=5; i++)
            {
                for(int j=0; j < 4; j++)
                {
                    Button b = new Button
                    {
                        Content = tab[k],
                        Background = (j == 3) ? Brushes.Orange : Brushes.Gray,
                        Foreground = (j==3) ? Brushes.White : Brushes.Black,
                        FontSize=30
                    };
                    grille.Children.Add(b);
                    Grid.SetColumn(b, j);
                    Grid.SetRow(b, i);
                    k++;
                    if(b.Content.ToString() == "0")
                    {
                        Grid.SetColumnSpan(b, 2);
                        j++;
                    }
                }
            }
        }
    }
}
