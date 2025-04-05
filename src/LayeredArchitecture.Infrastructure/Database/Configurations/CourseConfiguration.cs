using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LayeredArchitecture.Infrastructure.Database.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(course => course.Id);
        
        builder.Property(course => course.Name).HasMaxLength(100).IsRequired();

        builder.Property(course => course.Quota).IsRequired();
    }
}