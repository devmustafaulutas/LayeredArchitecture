using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LayeredArchitecture.Infrastructure.Database.Configurations;

public class PlannedCourseSessionConfiguration : IEntityTypeConfiguration<PlannedCourseSession>
{
    public void Configure(EntityTypeBuilder<PlannedCourseSession> builder)
    {
        builder.HasKey(plannedCourseSession => plannedCourseSession.Id);
        
        builder.Property(plannedCourseSession => plannedCourseSession.dateTime).IsRequired();

        builder.HasOne(plannedCourseSession => plannedCourseSession.plannedCourse)
                .WithMany(plannedCourse => plannedCourse.plannedCourseSessions)
                .HasForeignKey(plannedCourseSession => plannedCourseSession.plannedCourseId);

    }
}