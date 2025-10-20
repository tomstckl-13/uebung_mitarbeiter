using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MitarbeiterVewaltung.Lib.Modell;
using MitarbeiterVewaltung.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitarbeiterVerwaltung.Core.ViewModels
{
    public partial class ChartViewModel : ObservableObject
    {
        IRepository _rep;

        [ObservableProperty]
        ObservableCollection<Mitarbeiter> _mit = [];

       

        public ChartViewModel(IRepository rep)
        {
            _rep = rep;

            
        }

        bool isLoaded = false;

        [RelayCommand]
        void GetAll()
        {
            var mitarbeiter = _rep.GetAll();

            if (isLoaded == false) {
                foreach (var item in mitarbeiter)
                {
                    this.Mit.Add(item);
                }
                isLoaded = true;
            }

           
        }
    }
}
