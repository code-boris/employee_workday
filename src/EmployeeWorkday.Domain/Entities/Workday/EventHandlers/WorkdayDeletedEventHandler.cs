using EmployeeWorkday.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EmployeeWorkday.Domain.Entities.Workday.EventHandlers;

public class WorkdayDeletedEventHandler(ILogger<WorkdayDeletedEventHandler> logger)
    : INotificationHandler<WorkdayDeletedEvent>
{
    public Task Handle(WorkdayDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
