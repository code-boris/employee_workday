using MediatR;

namespace EmployeeWorkday.Mediator.MediatR;

public class RequestAdapter<TRequest, TResponse> : IRequest<TResponse>
{
    public RequestAdapter(TRequest value)
    {
        Value = value;
    }

    public TRequest Value { get; }
}