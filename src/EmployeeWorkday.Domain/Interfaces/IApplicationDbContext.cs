using EmployeeWorkday.Domain.Entities.Employee;
using EmployeeWorkday.Domain.Entities.Workday;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWorkday.Domain.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; set; }

    DbSet<WorkDay> Workdays { get; set; }

    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
}
