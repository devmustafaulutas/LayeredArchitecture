namespace LayeredArchitecture.Domain;

public class Student
{
    public int Id { get; set; }
    public string nameSurname { get; set; }
    public string parentNameSurname { get; set; }
    public string phone { get; set; }
    public string parentPhone { get; set; }

    public ICollection<StudentPayment> studentPayments { get; set; }
}