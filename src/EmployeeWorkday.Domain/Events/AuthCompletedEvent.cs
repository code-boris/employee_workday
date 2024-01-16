using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Common.Identity;

namespace EmployeeWorkday.Domain.Events;

public abstract class AuthCompletedEvent(ApplicationUser user) : BaseEvent
{
    public ApplicationUser User { get; } = user;
}
