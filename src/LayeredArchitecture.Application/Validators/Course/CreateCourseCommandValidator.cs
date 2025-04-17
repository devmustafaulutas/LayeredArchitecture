using FluentValidation;
using LayeredArchitecture.Application.Courses.Commands.CreateCourse;

namespace LayeredArchitecture.Application.Validators.Course;
public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Course name can not be empty !");

        RuleFor(c => c.Quota)
            .GreaterThan(0)
            .WithMessage("Course quota must be greater than 0");

        RuleFor(c => c.Time)
            .Must(time => time % 15 == 0)
            .WithMessage("Time must be multiple of 15")
            .InclusiveBetween(0,60)
            .WithMessage("Time must be between 0 and 60");

    }
}