using MitarbeiterVerwaltung.Core.ViewModels;

namespace MitarbeiterVerwaltung.Gui
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        
    }

}
