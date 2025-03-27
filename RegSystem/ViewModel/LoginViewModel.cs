using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Maui.Controls;

public class LoginViewModel : BaseViewModel
{
    private string _username;
    private string _password;

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
        LoginCommand = new Command(async () => await LoginAsync());
    }

    private async Task LoginAsync()
    {
        IsBusy = true;

        try
        {
            // โหลด JSON ไฟล์จาก Resources/Raw/detail.json
            var filePath = Path.Combine(FileSystem.AppDataDirectory, "detail.json");
            if (!File.Exists(filePath))
            {
                await Application.Current.MainPage.DisplayAlert("ข้อผิดพลาด", "ไม่พบไฟล์ข้อมูล", "ตกลง");
                return;
            }

            string json = await File.ReadAllTextAsync(filePath);
            var studentData = JsonSerializer.Deserialize<StudentData>(json);

            // ค้นหาผู้ใช้ที่ตรงกับ Email และ Password
            var student = studentData.Students.FirstOrDefault(s => s.Email == Username && s.Password == Password);

            if (student != null)
            {
                await Application.Current.MainPage.DisplayAlert("เข้าสู่ระบบสำเร็จ", $"ยินดีต้อนรับ {student.Name}", "ตกลง");
                // ไปที่หน้า ProfilePage.xaml
                await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage());
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("เข้าสู่ระบบล้มเหลว", "Email หรือ Password ไม่ถูกต้อง", "ลองอีกครั้ง");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error loading JSON: {ex.Message}");
            await Application.Current.MainPage.DisplayAlert("ข้อผิดพลาด", "เกิดปัญหาในการโหลดข้อมูล", "ตกลง");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
