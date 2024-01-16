using EmployeeWorkday.Domain.Entities.Workday;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeWorkday.Infrastructure.Data.Configurations;

public class WorkdayConfiguration : IEntityTypeConfiguration<WorkDay>
{
    public void Configure(EntityTypeBuilder<WorkDay> builder)
    {
        builder
            .HasOne(e => e.Employee)
            .WithMany(e => e.WorkDays)
            .HasForeignKey(x => x.EmployeeId);
        
        builder
            .Property(t => t.EndTime)
            .IsRequired();
        
        builder
            .Property(t => t.StartTime)
            .IsRequired();

        builder
            .HasKey(u => u.Id);
    }
}
