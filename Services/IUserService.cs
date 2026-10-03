using maui_project.Models;

namespace maui_project.Services;

public interface IUserService
{
    Task<User> CreateAsync(User user);
    Task<List<User>> GetAllAsync();
}