using MediatR;

namespace EmployeeWorkday.Mediator.MediatR;

public class MediatRAdapter : IApplicationMediator
{
    private readonly IMediator _myImpl;

    public MediatRAdapter(IMediator impl) =>
        _myImpl = impl;

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
    {
        return _myImpl.Publish(new NotificationAdapter<TNotification>(notification), cancellationToken);
    }

    public Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default)
    {
        return _myImpl.Send(new RequestAdapter<TRequest, TResponse>(request), cancellationToken);
    }
}
