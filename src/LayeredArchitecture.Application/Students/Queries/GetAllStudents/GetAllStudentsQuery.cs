using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Students.Queries.GetAllStudents;

public class GetAllStudentsQuery(ILayeredArchitectureDbContext dbContext)
{
    public List<StudentDto> Handle()
    {
        var students = dbContext.Students
        .Select(student => new StudentDto(
            student.Id ,
            student.nameSurname , 
            student.parentNameSurname ,
            student.phone ,
            student.parentPhone , 
            
            student.studentPayments.Sum(p => p.amount)
            -
            (            
                student.plannedCourseStudents.SelectMany(pcs => pcs.discontinuities)
                    .Where(d => d.discontinuity == true)
                    .Sum(d => d.plannedCourseStudent.price)
                -
                student.plannedCourseStudents.Sum(pcs => pcs.price)
            )

        ))
        .ToList();
        return students;
    }
}