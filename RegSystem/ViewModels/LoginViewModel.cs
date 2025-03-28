using System.Text.Json;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace RegSystem.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = "";
        private string _password = "";

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLogin);
        }

        private async void OnLogin()
        {
            string jsonData = @"{
                ""student"": {
                    ""id"": ""6310500456"",
                    ""email"": ""kanokwan.s@student.ku.ac.th"",
                    ""password"": ""securePass456"",
                    ""profile"": {
                        ""firstname"": ""กนกวรรณ"",
                        ""lastname"": ""สุขสมบูรณ์"",
                        ""nickname"": ""แนน"",
                        ""faculty"": ""วิทยาศาสตร์"",
                        ""department"": ""เทคโนโลยีสารสนเทศ"",
                        ""year"": 2,
                        ""advisor"": ""รศ.ดร.อนุชา เก่งกิจ"",
                        ""gpax"": 3.75
                    }
                }
            }";

            var data = JsonSerializer.Deserialize<LoginData>(jsonData);

            if (data != null && data.Student != null &&
    (Username == data.Student.Email || Username == data.Student.Id) && Password == data.Student.Password)
            {
                // ไปหน้า ProfilePage และส่งข้อมูลไปด้วย
                await Shell.Current.GoToAsync($"//ProfilePage?studentId={data.Student.Id}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Invalid username or password", "OK");
                //   await Shell.Current.GoToAsync("//Mainpage");
            }


        }
    }

    public class LoginData
    {
        public StudentData? Student { get; set; }
    }

    public class StudentData
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ProfileData? Profile { get; set; }
    }

    public class ProfileData
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Nickname { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public double Gpax { get; set; }
    }
}
