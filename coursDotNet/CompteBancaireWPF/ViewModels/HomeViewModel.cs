using CompteBancaireWPF.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaireWPF.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private Compte compte;
        private Compte compteSelected;
        private string search;
        private ObservableCollection<Compte> listeComptes;

        public event PropertyChangedEventHandler PropertyChanged;

        public Compte Compte
        {
            get => compte; set
            {
                compte = value;
                NotifyPropertyChanged("Compte");
            }
        }
        public string Search { get => search; set => search = value; }
        public ObservableCollection<Compte> ListeComptes
        {
            get => listeComptes; set
            {
                listeComptes = value;
                NotifyPropertyChanged("ListeComptes");
            }
        }

        public Compte CompteSelected { get => compteSelected; set => compteSelected = value; }

        public HomeViewModel()
        {
            Compte = new Compte();
            ListeComptes = Sauvegarde.Instance.ChercherComptes();
        }

        public void NotifyPropertyChanged(string nameProperty)
        {
            //if(PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(nameProperty));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }
    }
}
