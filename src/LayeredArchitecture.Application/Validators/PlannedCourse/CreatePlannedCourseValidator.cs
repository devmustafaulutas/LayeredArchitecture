using FluentValidation;
using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Application.PlannedCourses.Commands.CreatePlannedCourse;
using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Application.Validators.PlannedCourse;

public class CreatePlannedCourseValidator : AbstractValidator<CreatePlannedCourseCommand>
{
    public CreatePlannedCourseValidator(ILayeredArchitectureDbContext dbContext)
    {
        RuleFor(x => x)
            .MustAsync(async (Command, cancellationToken) =>
            {
                if (Command.startTime == null || Command.day == null)
                    return false;

                var plannedCoursesSameDay = await dbContext.PlannedCourses
                    .Include(pc => pc.Course)
                    .Where(pc => pc.DayOfWeek == Command.day)
                    .ToListAsync(cancellationToken);

                foreach (var course in plannedCoursesSameDay)
                {
                    var existingStart = course.StartTime;
                    var duration = course.Course?.Time ?? 0;
                    var existingEnd = existingStart + duration;

                    if (Command.startTime >= existingStart && Command.startTime < existingEnd)
                        return false;

                    if (existingEnd > Command.startTime)
                        return false;
                }

                return true;
            })
            .WithMessage("❌ Bu saat diliminde başka bir kurs var. Lütfen farklı bir zaman seçin.");
    }
}
