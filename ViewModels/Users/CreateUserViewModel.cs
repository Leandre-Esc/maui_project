using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_project.Models;
using maui_project.Services.Interfaces;

namespace maui_project.ViewModels.Users;

public partial class CreateUserViewModel : ObservableObject
{
    private readonly IUserService _service;
    
    public CreateUserViewModel(IUserService service)
    {
        _service = service;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string firstName = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string lastName = "";
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string username = "";
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string email = "";
    
    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string password = "";

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private bool isBusy;

    [ObservableProperty] private string message = "";

    [ObservableProperty] private bool isError;

    public ObservableCollection<User> Users { get; } = new();

    private bool CanSave() =>
        !IsBusy &&
        !string.IsNullOrWhiteSpace(Username) &&
        !string.IsNullOrWhiteSpace(Password) &&
        Email.Contains('@');

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        IsBusy = true;
        Message = "";
        IsError = false;

        try
        {
            var user = await _service.CreateAsync(new User
            {
                FirstName = FirstName.Trim(),
                LastName = LastName.Trim(),
                Username = Username.Trim(),
                Email = Email.Trim(),
                Password = Password.Trim()
            });

            Users.Add(user);
            Message = $"User {user.FirstName} {user.LastName} created (id {user.Id})!";

            FirstName = "";
            LastName = "";
            Username = "";
            Email = "";
            Password = "";
        }
        catch (HttpRequestException ex)
        {
            IsError = true;
            Message = $"Server error: {ex.Message}";
        }
        catch (TaskCanceledException)
        {
            IsError = true;
            Message = $"The request timed out. Check your connection.";
        }
        catch (Exception ex)
        {
            IsError = true;
            Message = $"Unexpected error: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
        }
    }
}
