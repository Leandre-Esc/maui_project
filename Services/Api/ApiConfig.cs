namespace maui_project.Services.Api;

public class ApiConfig
{
    private const string ApiBaseUrl = "http://51.11.240.246";

    public const string StagingPingUrl = $"{ApiBaseUrl}/api/ping";

    public static string BaseUrl => ApiBaseUrl;
}
