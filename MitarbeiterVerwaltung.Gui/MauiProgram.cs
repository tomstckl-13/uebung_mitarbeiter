using Microsoft.Extensions.Logging;
using MitarbeiterVerwaltung.Core.ViewModels;

namespace MitarbeiterVerwaltung.Gui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
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
#endif

            return builder.Build();
        }
    }
}
