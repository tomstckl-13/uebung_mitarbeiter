using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MitarbeiterVerwaltung.Core.Services;
using MitarbeiterVerwaltung.Core.ViewModels;
using MitarbeiterVerwaltung.Gui.Pages;
using MitarbeiterVerwaltung.Gui.Services;
using MitarbeiterVewaltung.Lib.Repositories;
using MitarbeiterVewaltung.Lib.Services;
using MitarbeiterVewaltung.Lib.Modell;
using Syncfusion.Maui.Core.Hosting;

namespace MitarbeiterVerwaltung.Gui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();


            //Singletons für ViewModels!
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<ChartViewModel>();

            //Singletons für Pages!
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<Chart>();

            string path = FileSystem.AppDataDirectory;
            string filename = "mitarbeiter.db";
            string fullpath = System.IO.Path.Join(path, filename);

            System.Diagnostics.Debug.WriteLine("Pfad:");
           


            //Singleton Schnittstelle
            builder.Services.AddSingleton<IRepository>(new SQLiteRepository(fullpath));
            builder.Services.AddSingleton<IAlertService, AlertService>();
#endif

            return builder.Build();
        }
    }
}
