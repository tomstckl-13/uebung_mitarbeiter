using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MitarbeiterVerwaltung.Core.ViewModels;
using MitarbeiterVewaltung.Lib.Repositories;
using MitarbeiterVewaltung.Lib.Services;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();


            //Singletons für ViewModels!
            builder.Services.AddSingleton<MainViewModel>();

            //Singletons für Pages!
            builder.Services.AddSingleton<MainPage>();

            string path = FileSystem.AppDataDirectory;
            string filename = "mitarbeiter.db";
            string fullpath = System.IO.Path.Join(path, filename);

            System.Diagnostics.Debug.WriteLine("Pfad:");
           


            //Singleton Schnittstelle
            builder.Services.AddSingleton<IRepository>(new SQLiteRepository(fullpath));

#endif

            return builder.Build();
        }
    }
}
