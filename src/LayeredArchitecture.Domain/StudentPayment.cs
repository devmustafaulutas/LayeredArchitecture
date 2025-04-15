using Microsoft.VisualBasic;

namespace LayeredArchitecture.Domain;
public class StudentPayment
{
    public Guid Id { get; set; }
    public decimal amount { get; set; }
    public DateTime paymentDate { get; set; }
    public Guid StudentId { get; set; }
    public Student student { get; set; }
    
    
    protected StudentPayment()
    {
        
    }
    public static StudentPayment Create(decimal amountParam  , Guid studentIdParam)
    {
        return new StudentPayment{
            Id = Guid.NewGuid(),
            amount = amountParam,
            paymentDate = DateTime.UtcNow,
            StudentId = studentIdParam
        };
    }
    public void Update(decimal amountParam )
    {
        amount = amountParam;
    }
    public ICollection<Student> students { get; set; }
}