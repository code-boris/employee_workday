using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Entities.Employee;

namespace EmployeeWorkday.Domain.Events;

public class EmployeeCreatedEvent(Employee employee) : BaseEvent
{
    public Employee Employee { get; } = employee;
}
