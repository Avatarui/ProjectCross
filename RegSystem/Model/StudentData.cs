public class StudentModel
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
}

public class StudentData
{
    public List<StudentModel> Students { get; set; }
}
