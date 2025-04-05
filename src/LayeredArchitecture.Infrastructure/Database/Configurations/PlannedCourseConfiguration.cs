using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LayeredArchitecture.Infrastructure.Database.Configurations;

public class PlannedCourseConfiguration : IEntityTypeConfiguration<PlannedCourse>
{
    public void Configure(EntityTypeBuilder<PlannedCourse> builder)
    {
        builder.HasKey(plannedCourse => plannedCourse.Id);

        builder.Property(plannedCourse => plannedCourse.DayOfWeek).IsRequired();
        
        builder.Property(plannedCourse => plannedCourse.StartTime).IsRequired();
        
        builder.HasOne(plannedCourse => plannedCourse.Course)
            .WithMany(course => course.PlannedCourses)
            .HasForeignKey(plannedCourse => plannedCourse.CourseId)
            .IsRequired();
    }
}