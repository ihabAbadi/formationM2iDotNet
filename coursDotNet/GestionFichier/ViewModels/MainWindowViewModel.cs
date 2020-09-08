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
using System.Windows.Threading;
using System.IO;

namespace GestionFichier.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        private Dossier dossier;
        public ICommand OpenFolder { get; set; }

        public ICommand ExportCommand { get; set; }

        public ExtensionFichier SelectedExtension { get; set; }

        public ObservableCollection<ExtensionFichier> Extensions { get; set; }

        public string Result { get; set; }

        public string Folder { get; set; }

        public string ExportFile { get; set; }

        public MainWindowViewModel()
        {
            OpenFolder = new RelayCommand(OpenFolderAction);
            ExportCommand = new RelayCommand(Export);
        }

        private void OpenFolderAction()
        {
            FolderBrowserDialog open = new FolderBrowserDialog();
            open.ShowDialog();
            Folder = open.SelectedPath;
            RaisePropertyChanged("Folder");
            dossier = new Dossier() { Chemin = Folder };
            Result = "En cours de chargement";
            RaisePropertyChanged("Result");
            Task.Factory.StartNew(() =>
            {
                dossier.Fichiers = Dossier.GetFiles(Folder);
                dossier.GetExtensions();
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    Extensions = dossier.Extensions.CastToObservable();
                    RaisePropertyChanged("Extensions");
                    Result = "chargement des extensions terminé";
                    RaisePropertyChanged("Result");
                });
            }); 
        }

        private void Export()
        {
            Result = "Export en cours";
            RaisePropertyChanged("Result");
            Task.Factory.StartNew(() =>
            {
                List<Fichier> liste = dossier.GetFilesByExtension(SelectedExtension);
                StreamWriter writer = new StreamWriter("export.csv");
                writer.WriteLine("nom;chemin;");
                liste.ForEach((e) =>
                {
                    writer.WriteLine($"{e.Nom};{e.Chemin}");
                });
                writer.Close();
                Dispatcher.CurrentDispatcher.Invoke(() =>
                {
                    Result = "Export términé";
                    RaisePropertyChanged("Result");
                    ExportFile = Path.Combine(Directory.GetCurrentDirectory(), "export.csv");
                    RaisePropertyChanged("ExportFile");
                });
            });
        }
    }
}
