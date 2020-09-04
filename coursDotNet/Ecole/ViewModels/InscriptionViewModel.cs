using Ecole.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ecole.ViewModels
{
    class InscriptionViewModel : ViewModelBase
    {
        private bool isProf;
        private bool isEtudiant;
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Adresse { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public Classe SelectedClasse{ get; set; }
        public Matiere SelectedMatiere { get; set; }
        public bool IsEtudiant { 
            get
            {
                return isEtudiant;
            }
            set 
            {
                isEtudiant = value;
                RaisePropertyChanged("VEtudiant");
            } 
        }
        public bool IsProf { 
            get 
            {
                return isProf;
            } 
            set 
            {
                isProf = value;
                RaisePropertyChanged("VProf");
            } 
        }

        public Visibility VEtudiant { get
            {
                if (IsEtudiant)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;
            }
        }

        public Visibility VProf
        {
            get
            {
                if (IsProf)
                    return Visibility.Visible;
                else
                    return Visibility.Hidden;
            }
        }

        public string Result { get; set; }
        
        public ObservableCollection<Classe> Classes { get; set; }

        public ObservableCollection<Matiere> Matieres { get; set; }

        public ICommand AddCommand { get; set; }

        //public Personne Personne { get; set; }

        public InscriptionViewModel()
        {
            Classes = Classe.GetClasses().CastToObservable();
            Matieres = Matiere.getMatieres().CastToObservable();
            AddCommand = new RelayCommand(Inscription);
            IsEtudiant = true;
        }

        private void Inscription()
        {
            if(IsEtudiant)
            {
                Etudiant e = new Etudiant()
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Telephone = Telephone,
                    Email = Email,
                    Adresse = Adresse,
                    CodePostal = CodePostal,
                    Ville = Ville,
                    Classe = SelectedClasse
                };
                if(e.Save())
                {
                    Result = "Etudiant ajouté avec l'id : " + e.Id;
                    
                }
                else
                {
                    Result = "Erreur serveur";
                }
            }
            else if(IsProf)
            {
                Prof p = new Prof()
                {
                    Nom = Nom,
                    Prenom = Prenom,
                    Telephone = Telephone,
                    Email = Email,
                    Adresse = Adresse,
                    CodePostal = CodePostal,
                    Ville = Ville,
                    Matiere = SelectedMatiere
                };
                if (p.Save())
                {
                    Result = "Prof ajouté avec l'id : " + p.Id;

                }
                else
                {
                    Result = "Erreur serveur";
                }
            }

            RaisePropertyChanged("Result");
        }

    }
}
