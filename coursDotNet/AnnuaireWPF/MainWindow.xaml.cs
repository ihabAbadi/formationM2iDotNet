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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnnuaireWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Contact contact;
        public MainWindow()
        {
            InitializeComponent();
            contact = new Contact();
            GetContacts();
        }

        private void Ajout_Mail_Click(object sender, RoutedEventArgs e)
        {
            List<Email> listeTmp = new List<Email>();
            contact.Emails.Add(new Email() { Mail = TextBoxMail.Text });
            TextBoxMail.Text = "";
            listeTmp.AddRange(contact.Emails);
            listeBoxEmails.ItemsSource = listeTmp;
        }

        private void Valid_Click(object sender, RoutedEventArgs e)
        {
            contact.Nom = TextBoxNom.Text;
            contact.Prenom = TextBoxPrenom.Text;
            contact.Telephone = TextBoxPhone.Text;
            
            if (contact.Save())
            {
                TextBoxPhone.Text = "";
                TextBoxNom.Text = "";
                TextBoxPrenom.Text = "";
                listeBoxEmails.ItemsSource = null;
                MessageBox.Show("Contact validé");
                GetContacts();
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
        }

        private void GetContacts()
        {
            listeBoxContacts.ItemsSource = Contact.GetContacts();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            listeBoxContacts.ItemsSource = Contact.GetContacts(TextBoxSearch.Text);
        }

       

        private void listeBoxContacts_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            DetailContact w = new DetailContact(listeBoxContacts.SelectedItem as Contact);
            w.Show();
        }
    }
}
