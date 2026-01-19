using Microsoft.Extensions.Logging;
using Pokedex.Services;
using Pokedex.ViewModels;
using Pokedex.Views;

namespace Pokedex;

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
#endif

        // Registrar HttpClient
        builder.Services.AddHttpClient();

        // Registrar Servicios
        builder.Services.AddSingleton<IPokeApiService, PokeApiService>();

        // Registrar ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<DetailViewModel>();

        // Registrar Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DetailPage>();

        return builder.Build();
    }
}