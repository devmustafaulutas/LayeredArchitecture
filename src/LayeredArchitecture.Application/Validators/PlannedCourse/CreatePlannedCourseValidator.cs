using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Validators.PlannedCourse;

public class CreatePlannedCourseValidator : AbstractValidator<CreatePlannedCourseDto>
{
    public CreatePlannedCourseValidator(ILayeredArchitectureDbContext dbContext)
    {
        RuleFor(x => x)
            .MustAsync(async (dto, cancellationToken) =>
            {
                if (dto.startTime == null || dto.day == null)
                    return false;

                var plannedCoursesSameDay = await dbContext.PlannedCourses
                    .Include(pc => pc.Course)
                    .Where(pc => pc.DayOfWeek == dto.day)
                    .ToListAsync(cancellationToken);

                foreach (var course in plannedCoursesSameDay)
                {
                    var existingStart = course.StartTime;
                    var duration = course.Course?.Time ?? 0;
                    var existingEnd = existingStart + duration;

                    if (dto.startTime >= existingStart && dto.startTime < existingEnd)
                        return false;

                    if (existingEnd > dto.startTime)
                        return false;
                }

                return true;
            })
            .WithMessage("❌ Bu saat diliminde başka bir kurs var. Lütfen farklı bir zaman seçin.");
    }
}
