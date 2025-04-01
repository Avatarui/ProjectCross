using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using RegSystem.ViewModels; // เพิ่ม namespace นี้

namespace RegSystem.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfilePageViewModel();
        }
        

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Logout", "คุณต้องการออกจากระบบใช่หรือไม่?", "ใช่", "ไม่");
            if (result)
            {
                // ล้างข้อมูลผู้ใช้
                Preferences.Remove("StudentData");
                
                // กลับไปหน้า Login
                await Shell.Current.GoToAsync("///MainPage");
            }
        }
        // private async void OnSearchAndRegisterClicked(object sender, EventArgs e)
        // {
        //     await Shell.Current.GoToAsync("///Registration");
            
        // }

        private async void OnCurrentRegistrationClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//Current");
        }

        // private async void OnPreviousRegistrationClicked(object sender, EventArgs e)
        // {
        //      await Shell.Current.GoToAsync("///Previous");
        // }

        // private async void OnWithdrawClicked(object sender, EventArgs e)
        // {
        //      await Shell.Current.GoToAsync("///Withdraw");
        // }
    }
}