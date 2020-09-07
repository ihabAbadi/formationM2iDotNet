using Ecole.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
        public string Result { get; set; }
        public Classe SelectedClasse{ get; set; }
        public Matiere SelectedMatiere { get; set; }

        public Personne SelectedPersonne { get; set; }
        
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

        public bool IsInscription { get; set; }

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

        
        
        public ObservableCollection<Classe> Classes { get; set; }

        public ObservableCollection<Matiere> Matieres { get; set; }

        public ObservableCollection<Etudiant> Etudiants { get; set; }
        public ObservableCollection<Prof> Profs { get; set; }

        public ICommand AddCommand { get; set; }

        public ICommand EditCommand { get; set; }

        //public Personne Personne { get; set; }

        public InscriptionViewModel()
        {
            Classes = Classe.GetClasses().CastToObservable();
            Matieres = Matiere.getMatieres().CastToObservable();
            Etudiants = Etudiant.GetEtudiants().CastToObservable();
            Profs = Prof.GetProfs().CastToObservable();
            AddCommand = new RelayCommand(Validation);
            EditCommand = new RelayCommand(EditPersonne);
            IsEtudiant = true;
        }


        private void Validation()
        {
            if(SelectedPersonne == null)
            {
                Inscription();
            }
            else
            {
                Modification();
                SelectedPersonne = null;
                RaisePropertyChanged("SelectedPersonne");
            }
        }

        private void Modification()
        {
            SelectedPersonne.Nom = Nom;
            SelectedPersonne.Prenom = Prenom;
            SelectedPersonne.Telephone = Telephone;
            SelectedPersonne.Adresse = Adresse;
            SelectedPersonne.Email = Email;
            SelectedPersonne.CodePostal = CodePostal;
            SelectedPersonne.Ville = Ville;
            if(SelectedPersonne is Etudiant e)
            {
                e.Classe = SelectedClasse;
                e.Update();
                Etudiants = Etudiant.GetEtudiants().CastToObservable();
                RaisePropertyChanged("Etudiants");
            }
            else if(SelectedPersonne is Prof p)
            {
                p.Matiere = SelectedMatiere;
                p.Update(); 
                Profs = Prof.GetProfs().CastToObservable();
                RaisePropertyChanged("Profs");
            }
            Clear();
            Result = "Modification effectuée";
            RaisePropertyChanged("Result");
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
                    Clear();
                    Result = "Etudiant ajouté avec l'id : " + e.Id;
                    Etudiants.Add(e);
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
                    Clear();
                    Result = "Prof ajouté avec l'id : " + p.Id;
                    Profs.Add(p);
                }
                else
                {
                    Result = "Erreur serveur";
                }
            }

            RaisePropertyChanged("Result");
        }

        private void Clear()
        {
            Type t = typeof(InscriptionViewModel);
            foreach(PropertyInfo p in t.GetProperties())
            {
                if(p.PropertyType == typeof(string))
                {
                    p.SetValue(this, "");
                    RaisePropertyChanged(p.Name);
                }
            }
        }

        private void EditPersonne()
        {
            Type t = typeof(InscriptionViewModel);
            foreach (PropertyInfo p in t.GetProperties())
            {
                if (p.PropertyType == typeof(string) && p.Name != "Result")
                {
                    string value = SelectedPersonne.GetType().GetProperties().FirstOrDefault(pp => pp.Name == p.Name).GetValue(SelectedPersonne).ToString();
                    p.SetValue(this, value);
                    RaisePropertyChanged(p.Name);
                }
            }

            if(SelectedPersonne is Etudiant e)
            {
                IsEtudiant = true;
                RaisePropertyChanged("IsEtudiant");
                SelectedClasse = Classes.FirstOrDefault((c) => c.Id == e.Classe.Id);
                RaisePropertyChanged("SelectedClasse");
            }
            else if (SelectedPersonne is Prof p)
            {
                IsProf = true;
                RaisePropertyChanged("IsProf");
                SelectedMatiere = Matieres.FirstOrDefault((c) => c.Id == p.Matiere.Id);
                RaisePropertyChanged("SelectedMatiere");
            }
            IsInscription = true;
            RaisePropertyChanged("IsInscription");
        }
    }
}
