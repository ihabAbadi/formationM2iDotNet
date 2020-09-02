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

        public HomeViewModel()
        {
            Compte = new Compte();
            ListeComptes = Sauvegarde.Instance.ChercherComptes();
        }

        public void NotifyPropertyChanged(string nameProperty)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProperty));
        }
    }
}
