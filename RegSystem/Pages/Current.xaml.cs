using RegSystem.ViewModels;

namespace RegSystem.Pages;

public partial class Current : ContentPage
{
	public Current()
	{
		InitializeComponent();
		// BindingContext = new SemesterViewModel();
	}
	private async void OnBackClicked(object sender, EventArgs e)
{
    await Shell.Current.GoToAsync("//ProfilePage"); // ย้อนกลับไปหน้าก่อนหน้า
}

}