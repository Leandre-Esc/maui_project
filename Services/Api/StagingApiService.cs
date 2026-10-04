using maui_project.Services.Interfaces;

namespace maui_project.Services.Api;

public sealed class StagingApiService : IStagingApiService
{
    private readonly HttpClient _client;

    public StagingApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<bool> PingAsync(CancellationToken cancellationToken = default)
    {
        using var response = await _client.GetAsync(ApiConfig.StagingPingUrl, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
