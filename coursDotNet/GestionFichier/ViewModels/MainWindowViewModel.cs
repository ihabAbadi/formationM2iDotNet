using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using GestionFichier.Models;
using System.Collections.ObjectModel;

namespace GestionFichier.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private Dossier dossier;
        public ICommand OpenFolder { get; set; }

        public ObservableCollection<ExtensionFichier> Extensions { get; set; }

        public string Folder { get; set; }

        public MainWindowViewModel()
        {
            OpenFolder = new RelayCommand(OpenFolderAction);
        }

        private void OpenFolderAction()
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            Folder = open.SelectedPath;
            RaisePropertyChanged("Folder");
            dossier = new Dossier() { Chemin = Folder };
            dossier.Fichiers = Dossier.GetFiles(Folder);
            dossier.GetExtensions();
            Extensions = dossier.Extensions.CastToObservable();
            RaisePropertyChanged("Extensions");
        }
    }
}
