using Microsoft.Extensions.Logging;
using PFakeStoreApiMovil.Data;
using PFakeStoreApiMovil.Services;

namespace PFakeStoreApiMovil
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
                });

            builder.Services.AddMauiBlazorWebView();
            //------------------------------------------------------------------
            builder.Services.AddSingleton<IProductoService, ProductoService>();
            builder.Services.AddSingleton<ICategoriaService, CategoriaService>();
            //-------------------------------------------------------------------

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}