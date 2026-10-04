namespace maui_project.Services.Interfaces;

public interface IStagingApiService
{
    Task<bool> PingAsync(CancellationToken cancellationToken = default);
}
