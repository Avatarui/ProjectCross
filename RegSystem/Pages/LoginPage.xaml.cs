

namespace RegSystem.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

	}
	public class LoginData
	{
		public string Uname { get; set; } = "";
		public string Pwd { get; set; } = "";
	}
	private  void Button_Clicked(object sender, EventArgs e)
	{
	}
	private  void ForgetPasswordTapped(object sender, EventArgs e)
	{
	}
}