using Ardalis.GuardClauses;
using EmployeeWorkday.Domain.Events;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Workday.Commands.DeleteWorkday;

public abstract record DeleteWorkdayCommand(Guid Id) : IRequest;

public class DeleteWorkdayCommandHandler(IApplicationDbContext context) 
    : IRequestHandler<DeleteWorkdayCommand>
{
    public async Task Handle(DeleteWorkdayCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Workdays
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.Workdays.Remove(entity);

        entity.AddDomainEvent(new WorkdayDeletedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);
    }

}
