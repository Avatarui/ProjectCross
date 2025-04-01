using System.Text.Json;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using RegSystem.Models;
using Microsoft.Maui.Storage;

namespace RegSystem.ViewModels
{
  public class ProfilePageViewModel : INotifyPropertyChanged
  {
    private StudentData? _studentData;
    private Semester? _currentSemester;
    // private StudentData? _studentData;

    public string FullName => $"{Student?.Profile?.Firstname} {Student?.Profile?.Lastname}";
    public string StudentId => Student?.Id ?? string.Empty;
    public string Email => Student?.Email ?? string.Empty;
    public string Department => Student?.Profile?.Department ?? string.Empty;
    public string Faculty => Student?.Profile?.Faculty ?? string.Empty;
    public string Year => Student?.Profile?.Year.ToString() ?? string.Empty;
    public string Gpax => Student?.Profile?.Gpax.ToString("F2") ?? string.Empty;
    public string Status => Student?.Profile?.Status ?? string.Empty;
    public string ProfileImage => Student?.Profile?.ProfileImage ?? string.Empty;

    public Student? Student => _studentData?.Student;

    public Semester? CurrentSemester
    {
      get => _currentSemester;
      set
      {
        _currentSemester = value;
        OnPropertyChanged(nameof(CurrentSemester));
      }
    }

    public ICommand LoadCurrentSemesterCommand { get; }

    public ProfilePageViewModel()
    {
      LoadStoredData();
    }
    private void LoadStoredData()
    {
      if (Preferences.ContainsKey("StudentData"))
      {
        string jsonData = Preferences.Get("StudentData", string.Empty);
        if (!string.IsNullOrEmpty(jsonData))
        {
          _studentData = JsonSerializer.Deserialize<StudentData>(jsonData);
          OnPropertyChanged(nameof(FullName));
          OnPropertyChanged(nameof(StudentId));
          OnPropertyChanged(nameof(Email));
          OnPropertyChanged(nameof(Department));
          OnPropertyChanged(nameof(Faculty));
          OnPropertyChanged(nameof(Year));
          OnPropertyChanged(nameof(Gpax));
          OnPropertyChanged(nameof(Status));
          OnPropertyChanged(nameof(ProfileImage));
        }
      }
    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}