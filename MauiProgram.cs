using Microsoft.Extensions.Logging;
using Tofu.Services;
using Tofu.View;
using Tofu.ViewModel;

namespace Tofu;

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
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
        builder.Services.AddSingleton<SupplierService>();
        builder.Services.AddSingleton<AnimalService>();

        builder.Services.AddSingleton<AnimalViewModel>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AnimalPage>();

        return builder.Build();
	}
}
