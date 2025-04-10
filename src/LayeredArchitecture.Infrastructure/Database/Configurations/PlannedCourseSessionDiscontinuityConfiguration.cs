using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LayeredArchitecture.Infrastructure.Database.Configurations;

public class PlannedCourseSessionDiscontinuityConfiguration : IEntityTypeConfiguration<PlannedCourseSessionDiscontinuity>
{
    public void Configure(EntityTypeBuilder<PlannedCourseSessionDiscontinuity> builder)
    {
        builder.HasKey(pcsd => pcsd.Id);
        builder.Property(pcsd => pcsd.price).HasPrecision(10,2);

        builder.HasOne(pcsd => pcsd.plannedCourseStudent)
                .WithMany().HasForeignKey(pcsd => pcsd.plannedCourseStudentId);
        builder.HasOne(pcsd => pcsd.plannedCourseSession)
                .WithMany().HasForeignKey(pcsd => pcsd.PlannedCourseSessionId);

        builder.HasIndex(pcsd => new { pcsd.plannedCourseStudentId , pcsd.PlannedCourseSessionId })
                .IsUnique();
    }
}