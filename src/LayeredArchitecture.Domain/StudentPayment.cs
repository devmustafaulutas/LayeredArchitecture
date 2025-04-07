namespace LayeredArchitecture.Domain;
public class StudentPayment
{
    public int Id { get; set; }
    public decimal amount { get; set; }
    public DateTime paymentDate { get; set; }
    public int StudentId { get; set; }
    public ICollection<Student> students { get; set; }
}