using LayeredArchitecture.Application.Abstractions.Database;
using LayeredArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LayeredArchitecture.Infrastructure.Database.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(student => student.Id);

        builder.Property(student => student.nameSurname).HasMaxLength(100).IsRequired();

        builder.Property(student => student.parentNameSurname).HasMaxLength(100).IsRequired();

        builder.Property(student => student.phone).HasMaxLength(15).IsRequired();

        builder.Property(student => student.parentPhone).HasMaxLength(15).IsRequired();
    }
}