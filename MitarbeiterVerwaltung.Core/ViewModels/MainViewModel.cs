using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MitarbeiterVewaltung.Lib.Modell;
using MitarbeiterVewaltung.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVerwaltung.Core.ViewModels
{
    public partial class MainViewModel(IRepository repository) : ObservableObject
    {
        IRepository _repository = repository;

        [ObservableProperty]
        public string vorname = string.Empty;

        [ObservableProperty]
        public string nachname = string.Empty;

        [ObservableProperty]
        public int alter;

        [ObservableProperty]
        public string abteilung = string.Empty;

        [ObservableProperty]
        public DateTime eintrittsDatum = DateTime.Now;

        [ObservableProperty]
        public bool istVollzeit = true;

        [RelayCommand]
        void Add()
        {
            Mitarbeiter mitarbeiter = new Mitarbeiter(this.Vorname, this.Nachname, this.Alter, this.Abteilung, this.EintrittsDatum, this.IstVollzeit);

            _repository.Add(mitarbeiter);

            this.Vorname = string.Empty;
            this.Nachname = string.Empty;
            this.Alter = 0;
            this.Abteilung = string.Empty;
            this.EintrittsDatum = DateTime.Now;
            this.IstVollzeit = true;


        }




    }
}
