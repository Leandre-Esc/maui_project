using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_project.Views.Shared;

public partial class AppHeaderView : ContentView
{
    public AppHeaderView()
    {
        InitializeComponent();
    }

    private async void OnCreateUserClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CreateUserPage");
    }

    private async void OnUsersClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//UsersPage");
    }
    
    private async void OnHomeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CreateUserPage");
    }
}
