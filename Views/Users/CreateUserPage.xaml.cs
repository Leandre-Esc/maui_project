using maui_project.ViewModels.Users;

namespace maui_project.Views.Users;

public partial class CreateUserPage : ContentPage
{
    public CreateUserPage(CreateUserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
