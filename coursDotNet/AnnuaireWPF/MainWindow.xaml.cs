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

        private bool isEdit;

        public Contact Contact { get => contact; set => contact = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }

        public MainWindow()
        {
            InitializeComponent();
            Contact = new Contact();
            GetContacts();
        }

        private void Ajout_Mail_Click(object sender, RoutedEventArgs e)
        {
            List<Email> listeTmp = new List<Email>();
            Contact.Emails.Add(new Email() { Mail = TextBoxMail.Text });
            TextBoxMail.Text = "";
            listeTmp.AddRange(Contact.Emails);
            listeBoxEmails.ItemsSource = listeTmp;
        }

        private void Valid_Click(object sender, RoutedEventArgs e)
        {
            Contact.Nom = TextBoxNom.Text;
            Contact.Prenom = TextBoxPrenom.Text;
            Contact.Telephone = TextBoxPhone.Text;
            bool error = (isEdit) ? !Contact.Update() : !Contact.Save();
            //if(isEdit)
            //{
            //    error = !Contact.Update();
            //}
            //else
            //{
            //    error = !Contact.Save();
            //}
            if (!error)
            {
                TextBoxPhone.Text = "";
                TextBoxNom.Text = "";
                TextBoxPrenom.Text = "";
                listeBoxEmails.ItemsSource = null;
                isEdit = false;
                contact = new Contact();
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
            DetailContact w = new DetailContact(listeBoxContacts.SelectedItem as Contact, this);
            w.Show();
        }
    }
}
