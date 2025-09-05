using MauiShopElectronics.Pages;
using MauiShopElectronics.Services;
using MauiShopElectronics.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;
using UraniumUI;

namespace MauiShopElectronics
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            var getAssembly = Assembly.GetExecutingAssembly();
            using (var stream = getAssembly.GetManifestResourceStream("MauiShopElectronics.appSettings.json"))
            {
                var config = new ConfigurationBuilder().AddJsonStream(stream).Build();

                builder.Configuration.AddConfiguration(config);
            }

                builder
                    .UseMauiApp<App>()
                    .UseUraniumUI()
                    .UseUraniumUIMaterial()
                    .UseUraniumUIMaterial()
                    .ConfigureFonts(fonts =>
                    {
                        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    });
            builder.Services.AddTransient<AuthorizationViewModel>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddSingleton<UserController>();
            builder.Services.AddTransient<MainPage>();

            Eliseev.MauiXamlBase64ImageToolkit.Controls.Init();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
