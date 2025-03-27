using RegSystem.Models;
using RegSystem.ViewModels;

namespace MiniprojectCross.Page;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new ShowDataStudent();
    }

}