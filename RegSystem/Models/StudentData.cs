// Models/StudentData.cs
using System.Text.Json.Serialization;

namespace RegSystem.Models
{
   public class StudentData
{
    [JsonPropertyName("student")]
    public Student Student { get; set; }

    [JsonPropertyName("currentSemester")]
    public Semester CurrentSemester { get; set; }

    [JsonPropertyName("previousSemesters")]
    public List<Semester> PreviousSemesters { get; set; }
}


    public class Student
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("profile")]
    public Profile Profile { get; set; }
}

public class Profile
{
    [JsonPropertyName("firstname")]
    public string Firstname { get; set; }

    [JsonPropertyName("lastname")]
    public string Lastname { get; set; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; set; }

    [JsonPropertyName("faculty")]
    public string Faculty { get; set; }

    [JsonPropertyName("department")]
    public string Department { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("advisor")]
    public string Advisor { get; set; }

    [JsonPropertyName("gpax")]
    public double Gpax { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("studentType")]
    public string StudentType { get; set; }

    [JsonPropertyName("entryYear")]
    public int EntryYear { get; set; }

    [JsonPropertyName("birthdate")]
    public string Birthdate { get; set; }

    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("profileImage")]
    public string ProfileImage { get; set; }
}

public class Semester
{
    [JsonPropertyName("academicYear")]
    public int AcademicYear { get; set; }

    [JsonPropertyName("term")]
    public int Term { get; set; }

    [JsonPropertyName("registrationStatus")]
    public string RegistrationStatus { get; set; }

    [JsonPropertyName("paymentStatus")]
    public string PaymentStatus { get; set; }

    [JsonPropertyName("registrationDate")]
    public DateTime RegistrationDate { get; set; }

    [JsonPropertyName("totalCredits")]
    public int TotalCredits { get; set; }

    [JsonPropertyName("totalFee")]
    public double TotalFee { get; set; }

    [JsonPropertyName("gpa")]
    public double? Gpa { get; set; }

    [JsonPropertyName("subjects")]
    public List<Subject> Subjects { get; set; }
}


    public class Subject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public int Section { get; set; }
        public int Credits { get; set; }
        public string Grade { get; set; }
        public string Instructor { get; set; }
        public List<Schedule> Schedule { get; set; }
        public DateTime? MidtermExam { get; set; }
        public DateTime? FinalExam { get; set; }
        public string Status { get; set; }
    }

    public class Schedule
    {
        public string Day { get; set; }
        public string Time { get; set; }
        public string Room { get; set; }
    }
}