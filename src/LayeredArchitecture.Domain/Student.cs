namespace LayeredArchitecture.Domain;

public class Student
{
    public Guid Id { get; set; }
    public string nameSurname { get; set; }
    public string parentNameSurname { get; set; }
    public string phone { get; set; }
    public string parentPhone { get; set; }

    protected Student()
    {

    }
    public static Student Create(string nameSurname , string parentNameSurname , string phone , string parentPhone)
    {
        return new Student{

            Id = Guid.NewGuid(),
            nameSurname = nameSurname,
            parentNameSurname = parentNameSurname,
            phone = phone,
            parentPhone = parentPhone
        };
    }
    public void Update(string nameSurnameParam , string parentNameSurnameParam , string phoneParam , string parentPhoneParam)
    {
        nameSurname = nameSurnameParam;
        parentNameSurname = parentNameSurnameParam;
        phone = phoneParam;
        parentPhone = parentPhoneParam;
    }
    
    public ICollection<StudentPayment> studentPayments { get; set; }
    public ICollection<PlannedCourseStudent> plannedCourseStudents { get; set; }
}