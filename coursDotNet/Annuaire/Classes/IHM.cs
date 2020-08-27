using System;
using System.Collections.Generic;
using System.Text;

namespace Annuaire.Classes
{
    class IHM
    {
        List<Contact> contacts;
        public void Start()
        {
            MenuPrincipal();
        }

        private void MenuPrincipal()
        {
            string choix;
            do
            {
                Console.Clear();
                Console.WriteLine("1 -- Ajouter un contact");
                Console.WriteLine("2 -- Supprimer un contact");
                Console.WriteLine("3 -- Rechercher un contact par téléphone");
                Console.WriteLine("4 -- Rechercher un contact par sont id");
                Console.WriteLine("5 -- Modifier un contact");
                Console.WriteLine("6 -- Afficher les contacts");
                Console.WriteLine("0 -- Quitter");
                Console.WriteLine();
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        AjouterContact();
                        RetourMenu();
                        break;
                    case "2":
                        SupprimerContact();
                        RetourMenu();
                        break;
                    case "3":
                        SearchContactTel();
                        RetourMenu();
                        break;
                    case "4":
                        SearchContactId();
                        RetourMenu();
                        break;
                    case "5":
                        ModifierContact();
                        RetourMenu();
                        break;
                    case "6":
                        AfficherContacts();
                        RetourMenu();
                        break;

                }
            }
            while (choix != "0");
        }

        private void AfficherContacts()
        {
            List<Contact> contacts = Contact.GetContacts();
            contacts.ForEach(c => Console.WriteLine(c.ToString()));
        }

        private void AjouterContact()
        {
            Console.WriteLine("Merci de saisir votre nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Merci de saisir votre prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Merci de saisir votre numéro de téléphone : ");
            string telephone = Console.ReadLine();
            Contact contact = new Contact(nom, prenom, telephone);
            AjouterEmail(contact);
            if(contact.Save())
            {
                Console.WriteLine("Contact enregistré avec l'id : " + contact.Id);
            }
        }

        private void SupprimerContact()
        {
            AfficherContacts();
            Console.WriteLine("Quel contact voulez-vous supprimer ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Contact contact = Contact.GetContactById(id);
            if (contact == null)
                Console.WriteLine("aucun contact avec cet id");
            else
            {
                if(contact.Delete())
                {
                    Console.WriteLine("Contact supprimé");
                }
            }
        }

        private void SearchContactTel()
        {
            Console.WriteLine("Merci de saisir le numéro de téléphone : ");
            string tel = Console.ReadLine();
            contacts = Contact.GetContacts(tel);
            contacts.ForEach(c => Console.WriteLine(c));
        }

        private void SearchContactId()
        {
            Console.WriteLine("Merci de saisir l'id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Contact contact = Contact.GetContactById(id);
            if (contact != null)
                Console.WriteLine(contact.ToString());
            else
                Console.WriteLine("Aucun contact avec cet id");
        }

        private void ModifierContact()
        {
            AfficherContacts();
            Console.WriteLine("Quel contact voulez-vous modifier ? Merci de saisir son id : ");
            Int32.TryParse(Console.ReadLine(), out int id);
            Contact contact = Contact.GetContactById(id);
            if(contact != null)
            {
                Console.WriteLine("Quelles données voulez-vous modifier ? ");
                Console.WriteLine("1 -- Nom");
                Console.WriteLine("2 -- Prénom");
                Console.WriteLine("3 -- Téléphone");
                Console.WriteLine("4 -- Email");
                Console.WriteLine("5 -- Ajouter un email");
                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("Merci de saisir le nouveau nom : ");
                        contact.Nom = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Merci de saisir le nouveau prénom : ");
                        contact.Prenom = Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Merci de saisir le nouveau numéro de téléphone : ");
                        contact.Telephone = Console.ReadLine();
                        break;
                    case "4":
                        ModifierMail(contact);
                        break;
                    case "5":
                        Console.WriteLine("Nouveau email :");
                        Email newEmail = new Email(Console.ReadLine(), contact.Id);
                        contact.Emails.Add(newEmail);
                        newEmail.Save();
                        break;
                }
                contact.Update();
            }
            
        }

        private void AjouterEmail(Contact contact)
        {
            string choix;
            do
            {
                Console.WriteLine("Merci de saisir votre email : ");
                string email = Console.ReadLine();
                Console.WriteLine("Voulez-vous saisir un autre email ?");
                Console.WriteLine("1 -- OUI");
                Console.WriteLine("2 -- NON");
                choix = Console.ReadLine();
                Email newEmail = new Email(email, contact.Id);
                contact.Emails.Add(newEmail);
            }
            while (choix != "2");
        }

        private void ModifierMail(Contact contact)
        {
            
            string reponse;

            do
            {
                contact.Emails.ForEach(e => Console.WriteLine(e.ToString()));
                Console.WriteLine("Quel email voulez-vous modifier ? Merci de saisir son id :");
                Int32.TryParse(Console.ReadLine(), out int idEmail);
                Email emailFound = contact.Emails.Find(e => e.Id == idEmail);
                string choix;
                Console.WriteLine("1 -- Supprimer email");
                Console.WriteLine("2 -- Modifier email");
                choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        contact.Emails.Remove(emailFound);
                        emailFound.Delete();
                        break;
                    case "2":
                        Console.WriteLine("Nouveau email :");
                        emailFound.Mail = Console.ReadLine();
                        emailFound.Update();
                        break;
                }
                Console.WriteLine("Voulez-vous modifier un autre l'email ? ");
                Console.WriteLine("1 -- OUI");
                Console.WriteLine("2 -- NON");
                reponse = Console.ReadLine();
            }
            while (reponse != "2");
        }

        private void RetourMenu()
        {
            Console.WriteLine("Appuyez sur Entrée pour retourner au menu");
            Console.ReadLine();
        }
    }
}
