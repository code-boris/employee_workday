using EmployeeWorkday.Domain.Entities.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeWorkday.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasMany(x => x.WorkDays)
            .WithOne(x => x.Employee)
            .HasForeignKey(x => x.EmployeeId);
        
        builder.Property(t => t.Name)
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(t => t.Id)
            .IsRequired();

        builder.HasKey(u => u.Id);
        builder.HasAlternateKey(u => u.Id);
    }
}
