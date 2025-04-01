// using RegSystem.Models;

// public class SemesterViewModel
// {
    
//     public Semester CurrentSemester { get; set; }

//     public string AcademicYear => CurrentSemester?.AcademicYear.ToString() ?? string.Empty;
//     public string Term => CurrentSemester?.Term.ToString() ?? string.Empty;
//     public string RegistrationStatus => CurrentSemester?.RegistrationStatus ?? string.Empty;
//     public string PaymentStatus => CurrentSemester?.PaymentStatus ?? string.Empty;
//     public string RegistrationDate => CurrentSemester?.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
//     public string TotalCredits => CurrentSemester?.TotalCredits.ToString() ?? string.Empty;
//     public string TotalFee => CurrentSemester?.TotalFee.ToString("F2") ?? string.Empty;
//     public string Gpa => CurrentSemester?.Gpa?.ToString("F2") ?? string.Empty;

//     public List<SubjectViewModel> Subjects
//     {
//         get
//         {
//             var subjectList = new List<SubjectViewModel>();
//             if (CurrentSemester?.Subjects != null)
//             {
//                 foreach (var subject in CurrentSemester.Subjects)
//                 {
//                     subjectList.Add(new SubjectViewModel(subject));
//                 }
//             }
//             return subjectList;
//         }
//     }
// }

// public class SubjectViewModel
// {
//     public string Id { get; set; }
//     public string Name { get; set; }
//     public string NameEng { get; set; }
//     public int Section { get; set; }
//     public int Credits { get; set; }
//     public string Instructor { get; set; }
//     public List<string> Schedule { get; set; }
//     public string MidtermExam { get; set; }
//     public string FinalExam { get; set; }
//     public string Status { get; set; }

//     public SubjectViewModel(Subject subject)
//     {
//         Id = subject.Id;
//         Name = subject.Name;
//         NameEng = subject.NameEng;
//         Section = subject.Section;
//         Credits = subject.Credits;
//         Instructor = subject.Instructor;
//         Schedule = subject.Schedule?.Select(s => $"{s.Day} {s.Time} {s.Room}").ToList();
//         // MidtermExam = subject.MidtermExam.("yyyy-MM-dd HH:mm:ss");
//         // FinalExam = subject.FinalExam.("yyyy-MM-dd HH:mm:ss");
//         Status = subject.Status;
//     }
    
// }
