using MediatR;

namespace EmployeeWorkday.Mediator.MediatR;

public class RequestHandlerAdapter<TRequest, TResponse> : IRequestHandler<RequestAdapter<TRequest, TResponse>, TResponse>
{
    private readonly IApplicationRequestHandler<TRequest, TResponse> _myImpl;

    // injected by DI container
    public RequestHandlerAdapter(IApplicationRequestHandler<TRequest, TResponse> impl)
    {
        _myImpl = impl ?? throw new ArgumentNullException(nameof(impl));
    }

    public Task<TResponse> Handle(RequestAdapter<TRequest, TResponse> request, CancellationToken cancellationToken)
    {
        return _myImpl.Handle(request.Value, cancellationToken);
    }
}
