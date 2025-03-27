using RegSystem.ViewModels;

namespace RegSystem.Pages
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            // You can implement any profile-specific logic here if needed,
            // but as per your request, JSON fetching is removed.
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Clear any user-related data (e.g., stored session or user details)
            // Example: Clear stored data using GetStorage, or any other method you're using to store data
            // GetStorage.Remove("userSession"); // Assuming you're using GetStorage for session management

            // Optionally, you can also clear the ViewModel data to reset the login state.
            var loginViewModel = BindingContext as LoginViewModel;
            if (loginViewModel != null)
            {
                loginViewModel.Username = string.Empty;
                loginViewModel.Password = string.Empty;
            }

            // Navigate to the LoginPage
            await Shell.Current.GoToAsync("//LoginPage");
        }



        private async void OnCurrentRegistrationClicked(object sender, EventArgs e)
        {
            await DisplayAlert("ข้อมูล", "แสดงข้อมูลลงทะเบียนเทอมปัจจุบัน", "ตกลง");
        }

        private async void OnPreviousRegistrationClicked(object sender, EventArgs e)
        {
            await DisplayAlert("ข้อมูล", "แสดงข้อมูลลงทะเบียนเทอมก่อนหน้า", "ตกลง");
        }

        private async void OnSearchAndRegisterClicked(object sender, EventArgs e)
        {
            await DisplayAlert("ข้อมูล", "ค้นหาและลงทะเบียนรายวิชา", "ตกลง");
        }

        private async void OnWithdrawClicked(object sender, EventArgs e)
        {
            await DisplayAlert("ข้อมูล", "ถอนรายวิชา", "ตกลง");
        }

        private async Task DisplayAlert(string title, string message, string cancel)
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window != null && window.Page != null)
            {
                await window.Page.DisplayAlert(title, message, cancel);
            }
        }

        private void OnImageLoadError(object sender, EventArgs e)
        {
            profileImage.Source = "user.png"; // Fallback to local image on error
        }
    }
}
