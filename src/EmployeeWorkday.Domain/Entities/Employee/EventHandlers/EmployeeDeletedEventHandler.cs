using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Employee.EventHandlers;

public class EmployeeDeletedEventHandler(ILogger<EmployeeDeletedEventHandler> logger)
    : INotificationHandler<WorkdayDeletedEvent>
{
    public Task Handle(WorkdayDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
