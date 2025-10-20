using MitarbeiterVerwaltung.Core.ViewModels;

namespace MitarbeiterVerwaltung.Gui.Pages;

public partial class Chart : ContentPage
{
	public Chart(ChartViewModel chart)
	{
		InitializeComponent();
		this.BindingContext = chart;
	}
}