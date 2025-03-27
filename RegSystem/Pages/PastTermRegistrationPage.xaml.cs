using MiniprojectCross.ViewModel;

namespace RegSystem.Pages;

public partial class PastTermRegistrationPage : ContentPage
{
	public PastTermRegistrationPage()
	{
		InitializeComponent();
		BindingContext = new ShowDataStudent();
	}
	private async void OnClickedHome(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
}