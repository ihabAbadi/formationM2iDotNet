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
        private Personne editPersonne;
        public event PropertyChangedEventHandler PropertyChanged;

        public Personne Personne { get => personne; set { personne = value; Notify("Personne"); } }
        public ObservableCollection<Personne> ListePersonnes { get => listePersonnes; set => listePersonnes = value; }
        public Personne EditPersonne { get => editPersonne; set { editPersonne = value; Notify("EditPersonne"); } }

        public ViewModelPersonne() 
        {
            Personne = new Personne();
            ListePersonnes = new ObservableCollection<Personne>();
        }

        public void Notify(string nameProperty)
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
           
        }
    }
}
