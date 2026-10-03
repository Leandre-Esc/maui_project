using maui_project.Models;

namespace maui_project.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    public Task<User> CreateAsync(User user)
    {
        user.Id = _users.Count + 1;
        _users.Add(user);
        return Task.FromResult(user);
    }

    public Task<List<User>> GetAllAsync() => Task.FromResult(_users.ToList());
}