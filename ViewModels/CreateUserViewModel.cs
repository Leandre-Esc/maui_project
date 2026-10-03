using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using maui_project.Models;
using maui_project.Services;

namespace maui_project.ViewModels;

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

    [ObservableProperty] private string message = "";

    public ObservableCollection<User> Users { get; } = new();

    private bool CanSave() =>
        !string.IsNullOrWhiteSpace(Username) &&
        Email.Contains('@');

    [RelayCommand(CanExecute = nameof(CanSave))]
    private async Task SaveAsync()
    {
        var user = await _service.CreateAsync(new User
        {
            FirstName = firstName.Trim(),
            LastName = lastName.Trim(),
            Username = username.Trim(),
            Email = email.Trim(),
            Password = password.Trim(),
        });
        
        Users.Add(user);
        Message = $"User {user.FirstName} {user.LastName} created successfully!";

        FirstName = "";
        LastName = "";
        Username = "";
        Email = "";
        Password = "";
    }
}