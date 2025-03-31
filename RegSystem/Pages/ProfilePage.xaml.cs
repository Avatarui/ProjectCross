using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // เพิ่ม namespace นี้

namespace RegSystem.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
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
    }
}