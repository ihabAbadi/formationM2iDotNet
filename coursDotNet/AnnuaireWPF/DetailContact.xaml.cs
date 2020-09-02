using AnnuaireWPF.Classes;
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

namespace AnnuaireWPF
{
    /// <summary>
    /// Logique d'interaction pour DetailContact.xaml
    /// </summary>
    public partial class DetailContact : Window
    {
        private Contact contact;
        private MainWindow mainWindow;
        public DetailContact()
        {
            InitializeComponent();
        }

        public DetailContact(Contact c, MainWindow w) : this()
        {
            contact = c;
            TextBlockNom.Text = contact.Nom;
            TextBlockPrenom.Text = contact.Prenom;
            TextBlockPhone.Text = contact.Telephone;
            listeBoxEmails.ItemsSource = contact.Emails;
            mainWindow = w;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            contact.Delete();
            mainWindow.listeBoxContacts.ItemsSource = Contact.GetContacts();
            this.Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.TextBoxNom.Text = contact.Nom;
            mainWindow.TextBoxPrenom.Text = contact.Prenom;
            mainWindow.TextBoxPhone.Text = contact.Telephone;
            mainWindow.listeBoxEmails.ItemsSource = contact.Emails;
            mainWindow.Contact = contact;
            mainWindow.IsEdit = true;
            this.Close();
        }
    }
}
