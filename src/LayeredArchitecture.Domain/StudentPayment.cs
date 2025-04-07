namespace LayeredArchitecture.Domain;
public class StudentPayment
{
    public Guid Id { get; set; }
    public decimal amount { get; set; }
    public DateTime paymentDate { get; set; }
    public Guid StudentId { get; set; }
    protected StudentPayment()
    {
        
    }
    public ICollection<Student> students { get; set; }
}