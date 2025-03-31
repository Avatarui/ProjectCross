using System.Text.Json;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using RegSystem.Models;

namespace RegSystem.ViewModels
{
    public class ProfilePageViewModel : INotifyPropertyChanged
    {
        private StudentData? _studentData;
        private Semester? _currentSemester;

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
            LoadStudentData();
            LoadCurrentSemesterCommand = new Command(ShowCurrentSemester);
        }

        private void LoadStudentData()
        {
            try
            {
                string jsonString = @"{
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
                    ""gpax"": 3.75,
                    ""status"": ""กำลังศึกษา"",
                    ""studentType"": ""ภาคปกติ"",
                    ""entryYear"": 2022,
                    ""birthdate"": ""2003-08-22"",
                    ""phoneNumber"": ""0897654321"",
                    ""address"": ""45/6 ซอย 2 ต.บางเขน อ.เมือง จ.กรุงเทพฯ 10220"",
                    ""profileImage"": ""https://th.bing.com/th/id/OIP.QkU4Q1Cup07jRTiwl2cGCQHaJQ?rs=1&pid=ImgDetMain""
                  }
                },
                ""currentSemester"": {
                  ""academicYear"": 2024,
                  ""term"": 1,
                  ""registrationStatus"": ""ลงทะเบียนแล้ว"",
                  ""paymentStatus"": ""ชำระเงินแล้ว"",
                  ""registrationDate"": ""2024-07-10T08:30:00"",
                  ""totalCredits"": 15,
                  ""totalFee"": 25000,
                  ""subjects"": [
                    {
                      ""id"": ""01418211"",
                      ""name"": ""โครงสร้างข้อมูลและอัลกอริทึม"",
                      ""nameEng"": ""Data Structures and Algorithms"",
                      ""section"": 1,
                      ""credits"": 3,
                      ""grade"": null,
                      ""instructor"": ""ผศ.ดร.สมเกียรติ เทพสถิต"",
                      ""schedule"": [
                        {
                          ""day"": ""จันทร์"",
                          ""time"": ""10:00-12:00"",
                          ""room"": ""SCB-203""
                        },
                        {
                          ""day"": ""พฤหัสบดี"",
                          ""time"": ""14:00-16:00"",
                          ""room"": ""คอมแลป 1""
                        }
                      ],
                      ""midtermExam"": ""2024-10-12T09:00:00"",
                      ""finalExam"": ""2024-12-15T13:00:00"",
                      ""status"": ""กำลังเรียน""
                    },
                    {
                      ""id"": ""01418222"",
                      ""name"": ""หลักการพัฒนาเว็บ"",
                      ""nameEng"": ""Web Development Principles"",
                      ""section"": 2,
                      ""credits"": 3,
                      ""grade"": null,
                      ""instructor"": ""อ.ภานุวัฒน์ พัฒนาเจริญ"",
                      ""schedule"": [
                        {
                          ""day"": ""อังคาร"",
                          ""time"": ""09:00-12:00"",
                          ""room"": ""SCB-101""
                        }
                      ],
                      ""midtermExam"": ""2024-10-14T13:00:00"",
                      ""finalExam"": ""2024-12-18T09:00:00"",
                      ""status"": ""กำลังเรียน""
                    },
                    {
                      ""id"": ""01418233"",
                      ""name"": ""ปฏิบัติการระบบปฏิบัติการ"",
                      ""nameEng"": ""Operating Systems Laboratory"",
                      ""section"": 1,
                      ""credits"": 2,
                      ""grade"": null,
                      ""instructor"": ""รศ.ดร.วินัย สุขุม"",
                      ""schedule"": [
                        {
                          ""day"": ""พุธ"",
                          ""time"": ""13:00-15:00"",
                          ""room"": ""LAB-204""
                        }
                      ],
                      ""midtermExam"": ""2024-10-16T10:00:00"",
                      ""finalExam"": ""2024-12-20T13:00:00"",
                      ""status"": ""กำลังเรียน""
                    },
                    {
                      ""id"": ""01418345"",
                      ""name"": ""การเรียนรู้ของเครื่อง"",
                      ""nameEng"": ""Machine Learning"",
                      ""section"": 1,
                      ""credits"": 3,
                      ""grade"": null,
                      ""instructor"": ""ผศ.ดร.ชยพล อัจฉริยะ"",
                      ""schedule"": [
                        {
                          ""day"": ""ศุกร์"",
                          ""time"": ""10:00-12:00"",
                          ""room"": ""SCB-305""
                        }
                      ],
                      ""midtermExam"": ""2024-10-18T09:00:00"",
                      ""finalExam"": ""2024-12-22T09:00:00"",
                      ""status"": ""กำลังเรียน""
                    },
                    {
                      ""id"": ""01355201"",
                      ""name"": ""การสื่อสารภาษาอังกฤษ"",
                      ""nameEng"": ""English Communication"",
                      ""section"": 2,
                      ""credits"": 3,
                      ""grade"": null,
                      ""instructor"": ""อ.อลิสา แพรวสุวรรณ"",
                      ""schedule"": [
                        {
                          ""day"": ""พฤหัสบดี"",
                          ""time"": ""10:00-12:00"",
                          ""room"": ""ENG-102""
                        }
                      ],
                      ""midtermExam"": ""2024-10-17T10:00:00"",
                      ""finalExam"": ""2024-12-21T09:00:00"",
                      ""status"": ""กำลังเรียน""
                    }
                  ]
                },
                ""previousSemesters"": [
                  {
                    ""academicYear"": 2023,
                    ""term"": 2,
                    ""registrationStatus"": ""ลงทะเบียนแล้ว"",
                    ""paymentStatus"": ""ชำระเงินแล้ว"",
                    ""registrationDate"": ""2023-12-15T09:00:00"",
                    ""totalCredits"": 18,
                    ""totalFee"": 24500,
                    ""gpa"": 3.80,
                    ""subjects"": [
                      {
                        ""id"": ""01418111"",
                        ""name"": ""พื้นฐานการเขียนโปรแกรม"",
                        ""nameEng"": ""Introduction to Programming"",
                        ""section"": 1,
                        ""credits"": 3,
                        ""grade"": ""A"",
                        ""instructor"": ""อ.กฤษณ์ ศรีสว่าง"",
                        ""schedule"": [
                          {
                            ""day"": ""จันทร์"",
                            ""time"": ""09:00-12:00"",
                            ""room"": ""SCB-201""
                          }
                        ],
                        ""status"": ""เรียนเสร็จสิ้น""
                      },
                      {
                        ""id"": ""01418122"",
                        ""name"": ""คณิตศาสตร์สำหรับคอมพิวเตอร์"",
                        ""nameEng"": ""Mathematics for Computer Science"",
                        ""section"": 1,
                        ""credits"": 3,
                        ""grade"": ""A-"",
                        ""instructor"": ""รศ.ดร.วรเชษฐ์ พิพัฒน์สกุล"",
                        ""schedule"": [
                          {
                            ""day"": ""พุธ"",
                            ""time"": ""13:00-16:00"",
                            ""room"": ""SCB-302""
                          }
                        ],
                        ""status"": ""เรียนเสร็จสิ้น""
                      },
                      {
                        ""id"": ""01418244"",
                        ""name"": ""ระบบดิจิทัล"",
                        ""nameEng"": ""Digital Systems"",
                        ""section"": 2,
                        ""credits"": 3,
                        ""grade"": ""B+"",
                        ""instructor"": ""ผศ.ดร.ปาริชาติ เทพทอง"",
                        ""schedule"": [
                          {
                            ""day"": ""ศุกร์"",
                            ""time"": ""09:00-12:00"",
                            ""room"": ""SCB-203""
                          }
                        ],
                        ""status"": ""เรียนเสร็จสิ้น""
                      }
                    ]
                  }
                ]
            }";

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                _studentData = JsonSerializer.Deserialize<StudentData>(jsonString, options);

                if (_studentData?.Student != null)
                {
                    // Set the CurrentSemester property from the loaded data
                    CurrentSemester = _studentData.CurrentSemester;
                    
                    Console.WriteLine("✅ JSON Loaded Successfully!");
                    Console.WriteLine($"📧 Loaded Username: {_studentData.Student.Email}");
                    Console.WriteLine($"🔑 Loaded Password: {_studentData.Student.Password}");
                }
                else
                {
                    Console.WriteLine("❌ Failed to load student data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error loading student data: {ex.Message}");
            }
        }

        private async void ShowCurrentSemester()
        {
            if (CurrentSemester != null && CurrentSemester.Subjects != null)
            {
                string message = $"📅 ปีการศึกษา {CurrentSemester.AcademicYear}/{CurrentSemester.Term}\n" +
                                 $"📌 สถานะ: {CurrentSemester.RegistrationStatus}\n" +
                                 $"💰 ค่าธรรมเนียม: {CurrentSemester.TotalFee} บาท\n" +
                                 $"📚 รายวิชาที่ลงทะเบียน:\n\n";

                foreach (var subject in CurrentSemester.Subjects)
                {
                    message += $"- {subject.Id}: {subject.Name} ({subject.Credits} หน่วยกิต)\n";
                }

                await Shell.Current.DisplayAlert("ข้อมูลลงทะเบียน เทอมปัจจุบัน", message, "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "ไม่พบข้อมูลการลงทะเบียน", "OK");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}