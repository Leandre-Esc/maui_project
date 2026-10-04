using maui_project.Models;

namespace maui_project.Services.Interfaces;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<List<User>> GetAllAsync();
}
