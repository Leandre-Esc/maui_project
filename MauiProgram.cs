using Microsoft.Extensions.Logging;
using maui_project.Services;
using maui_project.ViewModels;
using maui_project.Views;

namespace maui_project;

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

		builder.Services.AddSingleton<IUserService, UserService>();
		builder.Services.AddTransient<CreateUserViewModel>();
		builder.Services.AddTransient<CreateUserPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
