using EmployeeWorkday.Domain.Entities.Employee;
using EmployeeWorkday.Domain.Entities.Workday;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWorkday.Infrastructure.Data;

public sealed class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<WorkDay> WorkDays { get; set; }

    public AppDbContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=asupim55;Server=localhost;Port=5432;Database=quick-start;");
        base.OnConfiguring(optionsBuilder);
    }
}
