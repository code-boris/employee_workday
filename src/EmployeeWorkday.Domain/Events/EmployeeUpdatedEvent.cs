using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Entities.Employee;

namespace EmployeeWorkday.Domain.Events;

public class EmployeeUpdatedEvent(Employee employee) : BaseEvent
{
    public Employee Employee { get; } = employee;
}
