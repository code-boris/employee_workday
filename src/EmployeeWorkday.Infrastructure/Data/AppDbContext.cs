using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EmployeeWorkday.Domain;
using EmployeeWorkday.Domain.Model;

namespace EmployeeWorkday.Infrastructure;

public class AppDbContext: DbContext
{

    IConfiguration appConfig;
    
    public AppDbContext(IConfiguration config)
    {
        appConfig = config;
    }
    
    public DbSet<Employee> Employees { get; set; }
    public DbSet<WorkDay> WorkDays { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DefaultConnection"));

}