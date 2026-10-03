using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maui_project.ViewModels;

namespace maui_project.Views;

public partial class CreateUserPage : ContentPage
{
    public CreateUserPage(CreateUserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}