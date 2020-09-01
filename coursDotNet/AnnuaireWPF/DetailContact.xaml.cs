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
        public DetailContact()
        {
            InitializeComponent();
        }

        public DetailContact(Contact c) : this()
        {
            contact = c;
            TextBlockNom.Text = contact.Nom;
            TextBlockPrenom.Text = contact.Prenom;
            TextBlockPhone.Text = contact.Telephone;
            listeBoxEmails.ItemsSource = contact.Emails;
        }
    }
}
