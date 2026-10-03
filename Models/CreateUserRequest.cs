using System.Text.Json.Serialization;

namespace maui_project.Models;

public class CreateUserRequest
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = "";

    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = "";

    [JsonPropertyName("userName")]
    public string Username { get; set; } = "";

    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
}
