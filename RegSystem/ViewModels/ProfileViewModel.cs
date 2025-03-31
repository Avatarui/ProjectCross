// ViewModels/ProfilePageViewModel.cs
using System.ComponentModel;
using Microsoft.Maui.Controls;
using RegSystem.Models;
using Microsoft.Maui.Storage; // เพิ่ม namespace นี้
using System.Text.Json; // เพิ่ม namespace นี้

namespace RegSystem.ViewModels
{
    public class ProfilePageViewModel : INotifyPropertyChanged
    {
        private StudentData _studentData;
        private string _fullName;
        private string _email;
        private string _profileImage;
        private string _department;
        private string _faculty;
        private string _year;
        private string _gpax;
        private string _status;
        private string _studentId;

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string ProfileImage
        {
            get => _profileImage;
            set
            {
                _profileImage = value;
                OnPropertyChanged(nameof(ProfileImage));
            }
        }

        public string Department
        {
            get => _department;
            set
            {
                _department = value;
                OnPropertyChanged(nameof(Department));
            }
        }

        public string Faculty
        {
            get => _faculty;
            set
            {
                _faculty = value;
                OnPropertyChanged(nameof(Faculty));
            }
        }

        public string Year
        {
            get => _year;
            set
            {
                _year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public string Gpax
        {
            get => _gpax;
            set
            {
                _gpax = value;
                OnPropertyChanged(nameof(Gpax));
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public string StudentId
        {
            get => _studentId;
            set
            {
                _studentId = value;
                OnPropertyChanged(nameof(StudentId));
            }
        }

        public ProfilePageViewModel()
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            // ดึงข้อมูล JSON จาก Preferences
            string jsonData = Preferences.Get("StudentData", "");
            
            if (!string.IsNullOrEmpty(jsonData))
            {
                try
                {
                    // แปลงจาก JSON string เป็น StudentData object
                    _studentData = JsonSerializer.Deserialize<StudentData>(jsonData);
                    
                    // กำหนดค่าให้กับ properties
                    FullName = $"{_studentData.Student.Profile.Firstname} {_studentData.Student.Profile.Lastname}";
                    Email = _studentData.Student.Email;
                    ProfileImage = _studentData.Student.Profile.ProfileImage ?? "user.png";
                    Department = _studentData.Student.Profile.Department;
                    Faculty = _studentData.Student.Profile.Faculty;
                    Year = $"ชั้นปีที่ {_studentData.Student.Profile.Year}";
                    Gpax = $"GPAX: {_studentData.Student.Profile.Gpax:F2}";
                    Status = _studentData.Student.Profile.Status;
                    StudentId = _studentData.Student.Id;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deserializing student data: {ex.Message}");
                    SetDefaultValues();
                }
            }
            else
            {
                SetDefaultValues();
            }
        }

        private void SetDefaultValues()
        {
            // ข้อมูลเริ่มต้นหากไม่มีข้อมูลนักศึกษา
            FullName = "Guest User";
            Email = "guest@example.com";
            ProfileImage = "user.png";
            Department = "";
            Faculty = "";
            Year = "";
            Gpax = "";
            Status = "";
            StudentId = "";
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}