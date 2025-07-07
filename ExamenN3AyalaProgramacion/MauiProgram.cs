using Microsoft.Extensions.Logging;
using ExamenN3AyalaProgramacion.Interfaces;
using ExamenN3AyalaProgramacion.Repositories;
using ExamenN3AyalaProgramacion.ViewModels;
using ExamenN3AyalaProgramacion.Views;

namespace ExamenN3AyalaProgramacion
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
            builder.Services.AddSingleton<IClienteInterface, ClienteRepository>();

            builder.Services.AddTransient<ClienteViewModel>();
            builder.Services.AddTransient<RegistroClientePage>();
            builder.Services.AddTransient<ListaClientesPage>();
            builder.Services.AddTransient<LogPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
