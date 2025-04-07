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
    public ICollection<StudentPayment> studentPayments { get; set; }
}