namespace RegSystem.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

        private async void ForgetPasswordTapped(object sender, EventArgs e)
        {
            var window = Application.Current?.Windows.FirstOrDefault();
            if (window != null && window.Page != null)
            {
                await window.Page.DisplayAlert("Forget Password", "โปรดติดต่อผู้ดูแลระบบเพื่อรีเซ็ตรหัสผ่าน", "OK");
            }
        }

        // You can add other functionality like 'Login' here
        // but if no checks are needed, you can skip any validation or verification
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Simply navigate to the ProfilePage when login is pressed
            await Shell.Current.GoToAsync("//ProfilePage");
        }
    }
}
