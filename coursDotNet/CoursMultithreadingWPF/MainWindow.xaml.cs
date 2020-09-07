using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Forms;


namespace CoursMultithreadingWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Thread.Sleep(10000);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //label.Content = "En cours d'execution";
            ////Task sans resultat
            //Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(5000);
            //    //Invoke main thread 
            //    Dispatcher.Invoke(() =>
            //    {
            //        label.Content = "Fin d'execution";
            //    });

            //});
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //pour ouvir une boite de dialogue pour selectionner un fichier
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();

            System.Windows.Forms.MessageBox.Show(open.FileName);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Pour choisir un dossier
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            System.Windows.MessageBox.Show(open.SelectedPath);
        }
    }
}
