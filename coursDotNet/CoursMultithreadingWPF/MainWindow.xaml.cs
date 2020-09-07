using Microsoft.Win32;
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
    }
}
