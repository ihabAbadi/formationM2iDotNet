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
    /// Logique d'interaction pour Taquin.xaml
    /// </summary>
    public partial class Taquin : Window
    {
        private int taille;
        private string winnerString = "";
        public Taquin()
        {
            InitializeComponent();
        }

        private void ClickStartGame(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            if(!Int32.TryParse(tailleGrille.Text, out taille))
            {
                MessageBox.Show("Merci de saisir un entier");
            }
            else
            {
                ClearGrid();
                CreateGrid();
            }
            
        }

        private void ClearGrid()
        {
            gridGame.Children.Clear();
            gridGame.RowDefinitions.Clear();
            gridGame.ColumnDefinitions.Clear();
            winnerString = "";
        }
        private void CreateGrid()
        {
            for(int i=1; i<= taille; i++)
            {
                gridGame.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                gridGame.ColumnDefinitions.Add(new ColumnDefinition{ Width= new GridLength(1, GridUnitType.Star) });
            }
            char[] tab = new char[taille * taille - 1];
            char c = 'A';
            int k = 0;
            while(k < taille * taille-1)
            {
                tab[k] = c;
                winnerString += c;
                c++;
                k++;
                
            }
            winnerString += "#";
            tab.Shuffle();
            k = 0;
            for(int i=0; i < taille;  i++)
            {
                for(int j=0; j < taille; j++)
                {
                    if(k < taille*taille - 1)
                    {
                        Button b = new Button
                        {
                            Content = tab[k].ToString(),
                            FontSize = 30
                        };
                        b.Click += ClickButton;
                        k++;
                        gridGame.Children.Add(b);
                        Grid.SetRow(b, i);
                        Grid.SetColumn(b, j);
                    }
                }
            }
        }

        private void ClickButton(object sender ,  RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                int i = Grid.GetRow(b);
                int j = Grid.GetColumn(b);
                
                if(j < taille-1 && IsFree(i,j+1))
                {
                    Move(b, i, j + 1);
                }
                else if(j > 0 && IsFree(i,j-1))
                {
                    Move(b, i, j - 1);
                }
                else if( i < taille-1 && IsFree(i+1, j))
                {
                    Move(b, i + 1, j);
                }
                else if(i > 0 && IsFree(i-1, j))
                {
                    Move(b, i - 1, j);
                }

                if(IsWin())
                {
                    MessageBox.Show("Bravo vous avez gagné");
                }
            }
        }

        private bool IsFree(int i, int j)
        {
            //bool free = true;   
            //foreach(UIElement e in gridGame.Children)
            //{
            //    if(Grid.GetRow(e) == i && Grid.GetColumn(e) == j)
            //    {
            //        free = false;
            //    }
            //}
            //return free;
            return gridGame.Children.Cast<UIElement>().FirstOrDefault(el => Grid.GetColumn(el) == j && Grid.GetRow(el) == i) == null;
            
        }
        private bool IsWin()
        {
            string tmpString = "";
            for(int i= 0; i < taille; i++)
            {
                for(int j=0; j < taille; j++)
                {
                    UIElement element = gridGame.Children.Cast<UIElement>().FirstOrDefault(el => Grid.GetColumn(el) == j && Grid.GetRow(el) == i);
                    if(element == null)
                    {
                        tmpString += "#";
                    }
                    else
                    {
                        tmpString += ((Button)element).Content.ToString();
                    }
                }
            }
            return tmpString == winnerString;
        }

        private void Move(Button b, int i, int j)
        {
            Grid.SetRow(b, i);
            Grid.SetColumn(b, j);
        }
    }
}
