using MiniprojectCross.ViewModel;

namespace RegSystem.Pages;

public partial class CourseWithdrawPage : ContentPage
{
	public CourseWithdrawPage()
	{
		InitializeComponent();
		BindingContext = new ShowDataStudent();
	}
	private async void OnClickedHome(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}