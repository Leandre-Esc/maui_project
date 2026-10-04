using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_project.ViewModels.Users;

namespace maui_project.Views.Users;

public partial class UsersPage : ContentPage
{
    public UsersPage(UsersViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}