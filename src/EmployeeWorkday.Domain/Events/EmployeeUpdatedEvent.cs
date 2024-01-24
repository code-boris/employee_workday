using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Entities.Employee;

namespace EmployeeWorkday.Domain.Events;

public abstract class EmployeeUpdatedEvent(Employee employee) : BaseEvent
{
    public Employee Employee { get; } = employee;
}
