using System;
using Microsoft.Maui.Controls;
using RegSystem.Pages;
using RegSystem.ViewModels;
namespace RegSystem.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
		BindingContext = new LoginViewModel();
    }

}
