using Ecole.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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
            InitialLoad();
            AddCommand = new RelayCommand(Validation);
            EditCommand = new RelayCommand(EditPersonne);
            IsEtudiant = true;
        }

        private void InitialLoad()
        {
            Result = "chargement en cours...";
            RaisePropertyChanged("Result");
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(10000);
                ObservableCollection<Classe> listeClasses = Classe.GetClasses().CastToObservable();
                ObservableCollection<Matiere> listeMatieres = Matiere.getMatieres().CastToObservable();
                ObservableCollection<Etudiant> listeEtudiants = Etudiant.GetEtudiants().CastToObservable();
                ObservableCollection<Prof> listeProfs = Prof.GetProfs().CastToObservable();
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    Classes = listeClasses;
                    RaisePropertyChanged("Classes");
                    Matieres = listeMatieres;
                    RaisePropertyChanged("Matieres");
                    Etudiants = listeEtudiants;
                    RaisePropertyChanged("Etudiants");
                    Profs = listeProfs;
                    RaisePropertyChanged("Profs");
                    Result = "";
                    RaisePropertyChanged("Result");
                });
            });
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
                Task.Factory.StartNew(() =>
                {
                    string tmpResult = "";
                    if (e.Save())
                    {
                        Clear();
                        tmpResult = "Etudiant ajouté avec l'id : " + e.Id;
                    }
                    else
                    {
                        tmpResult = "Erreur serveur";
                    }
                    Dispatcher.CurrentDispatcher.Invoke(() =>
                    {
                        Result = tmpResult;
                        Etudiants = Etudiant.GetEtudiants().CastToObservable();
                        RaisePropertyChanged("Etudiants");
                        RaisePropertyChanged("Result");
                    });
                });
                
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
