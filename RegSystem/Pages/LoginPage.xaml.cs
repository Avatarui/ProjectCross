using RegSystem.ViewModel;

namespace RegSystem.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
	public class LoginData
	{
		public string Uname { get; set; } = "";
		public string Pwd { get; set; } = "";
	}
	private async void Button_Clicked(object sender, EventArgs e)
	{
	}
	private async void ForgetPasswordTapped(object sender, EventArgs e)
	{
	}
}