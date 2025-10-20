using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MitarbeiterVerwaltung.Core.Services;
using MitarbeiterVewaltung.Lib.Modell;
using MitarbeiterVewaltung.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVerwaltung.Core.ViewModels
{
    public partial class MainViewModel(IRepository repository, IAlertService alertservice) : ObservableObject
    {
        IRepository _repository = repository;
        IAlertService _alertservice = alertservice;

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

        [ObservableProperty]
        ObservableCollection<Mitarbeiter> _mit = [];

        [ObservableProperty]
        Mitarbeiter _selectedMitarbeiter = null;

        bool isLoaded = false;


        [RelayCommand]
        void Add()
        {
            Mitarbeiter mitarbeiter = new Mitarbeiter(this.Vorname, this.Nachname, this.Alter, this.Abteilung, this.EintrittsDatum, this.IstVollzeit);

            _repository.Add(mitarbeiter);
            this.Mit.Add(mitarbeiter);
            _alertservice.ShowAlert("Erfolgreich!", "Der Eintrag wurde hinzugefügt");

            this.Vorname = string.Empty;
            this.Nachname = string.Empty;
            this.Alter = 0;
            this.Abteilung = string.Empty;
            this.EintrittsDatum = DateTime.Now;
            this.IstVollzeit = true;



        }

        [RelayCommand]
        void GetAll()
        {
            List<Mitarbeiter> Mitarbeiterinnen = _repository.GetAll();

            if(isLoaded == false)
            {
                foreach (var item in Mitarbeiterinnen)
                {
                    Mit.Add(item);
                }
                isLoaded = true;
            }

           
        }

        [RelayCommand]
        void Delete()
        {
            _repository.Delete(_selectedMitarbeiter.Id);
            this.Mit.Remove(_selectedMitarbeiter);
        }

        [RelayCommand]  
        void Update()
        {
            _repository.Update(this.SelectedMitarbeiter.Id, this.SelectedMitarbeiter.Vorname, this.SelectedMitarbeiter.Nachname, this.SelectedMitarbeiter.Alter, this.SelectedMitarbeiter.Abteilung, this.SelectedMitarbeiter.EintrittsDatum, this.SelectedMitarbeiter.IstVollzeit);
            int pos = this.Mit.IndexOf(_selectedMitarbeiter);
            if (pos != -1)
            {
                this.Mit[pos] = _selectedMitarbeiter;
            }

        }



    }
}
