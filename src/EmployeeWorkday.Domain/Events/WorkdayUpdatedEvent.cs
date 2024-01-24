using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Entities.Workday;

namespace EmployeeWorkday.Domain.Events;

public abstract class WorkdayUpdatedEvent(WorkDay workday) : BaseEvent
{
    public WorkDay WorkDay { get; } = workday;
}
