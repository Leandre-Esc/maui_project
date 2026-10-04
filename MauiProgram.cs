using Microsoft.Extensions.Logging;
using maui_project.Services.Api;
using maui_project.Services.Interfaces;
using maui_project.ViewModels.Users;
using maui_project.Views.Users;

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

		builder.Services.AddHttpClient<IUserService, ApiUserService>(client =>
		{
			client.BaseAddress = new Uri(ApiConfig.BaseUrl);
			client.Timeout = TimeSpan.FromSeconds(15);
		});
		
		builder.Services.AddTransient<CreateUserViewModel>();
		builder.Services.AddTransient<CreateUserPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
