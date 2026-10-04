using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_project.Models;
using maui_project.Services.Interfaces;

namespace maui_project.ViewModels.Users;

public partial class UsersViewModel : ObservableObject
{
    private readonly IUserService _service;

    public ObservableCollection<User> Users { get; } = new();

    [ObservableProperty] private bool isBusy;
    [ObservableProperty] private string message = "";
    
    public UsersViewModel(IUserService service)
    {
        _service = service;
    }

    [RelayCommand]
    private async Task LoadUsersAsync()
    {
        if (IsBusy)
            return;
        
        IsBusy = true;
        Message = "";

        try
        {
            var users = await _service.GetAllAsync();

            Users.Clear();

            foreach (var user in users)
                Users.Add(user);
        }
        catch (Exception ex)
        {
            Message = $"Error: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}