using System.Net.Http.Json;
using maui_project.Models;

namespace maui_project.Services;

public class ApiUserService : IUserService
{
    private readonly HttpClient _client;

    public ApiUserService(HttpClient client)
    {
        _client = client;
    }

    public async Task<User> CreateAsync(User user)
    {
        var request = new CreateUserRequest
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Username = user.Username,
            Email = user.Email,
            Password = user.Password
        };

        var response = await _client.PostAsJsonAsync("/api/users", request);
        response.EnsureSuccessStatusCode();

        var created = await response.Content.ReadFromJsonAsync<User>();
        return created ?? throw new InvalidOperationException("Empty response form API");
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _client.GetFromJsonAsync<List<User>>("api/users") ?? new();
    }
}
