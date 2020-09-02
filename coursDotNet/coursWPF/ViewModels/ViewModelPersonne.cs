using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursWPF.ViewModels
{
    public class ViewModelPersonne : INotifyPropertyChanged
    {
        private Personne personne;

        //private List<Personne> listePersonnes;
        private ObservableCollection<Personne> listePersonnes;

        public event PropertyChangedEventHandler PropertyChanged;

        public Personne Personne { get => personne; set => personne = value; }
        public ObservableCollection<Personne> ListePersonnes { get => listePersonnes; set => listePersonnes = value; }

        public ViewModelPersonne()
        {
            Personne = new Personne();
            ListePersonnes = new ObservableCollection<Personne>();
        }

        private void Notify(string nameProperty)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameProperty));
            }
        }

        public void AddPersonne()
        {
            ListePersonnes.Add(Personne);
            Personne = new Personne();
            //Notify("ListePersonnes");
            Notify("Personne");
        }
    }
}
