using maui_project.Services.Interfaces;

namespace maui_project;

public partial class App : Application
{
    private readonly IStagingApiService _stagingApiService;

    public App(IStagingApiService stagingApiService)
    {
        _stagingApiService = stagingApiService;
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var shell = new AppShell();
        var window = new Window(shell);
        window.Created += async (_, _) => await CheckStagingApiAsync(shell);
        return window;
    }

    private async Task CheckStagingApiAsync(Page page)
    {
        try
        {
            var isConnected = await _stagingApiService.PingAsync();

            await page.DisplayAlertAsync(
                "API de staging",
                isConnected
                    ? "Vous êtes bien connecté à l’API de staging."
                    : "La connexion à l’API de staging a échoué.",
                "OK");
        }
        catch (Exception)
        {
            await page.DisplayAlertAsync(
                "API de staging",
                "Impossible de joindre l’API de staging. Vérifiez votre connexion réseau.",
                "OK");
        }
    }
}
