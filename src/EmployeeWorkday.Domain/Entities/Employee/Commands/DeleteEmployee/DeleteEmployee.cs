using Ardalis.GuardClauses;
using EmployeeWorkday.Domain.Events;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Employee.Commands.DeleteEmployee;

public abstract record DeleteEmployeeCommand(int Number) : IRequest;

public class DeleteEmployeeCommandHandler(IApplicationDbContext context) 
    : IRequestHandler<DeleteEmployeeCommand>
{
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Employees
            .FindAsync(new object[] { request.Number }, cancellationToken);

        Guard.Against.NotFound(request.Number.ToString(), entity);

        context.Employees.Remove(entity);

        entity.AddDomainEvent(new EmployeeDeletedEvent(entity));

        await context.SaveChangesAsync(cancellationToken);
    }

}
