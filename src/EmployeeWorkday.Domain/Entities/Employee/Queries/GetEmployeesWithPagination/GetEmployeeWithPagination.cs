using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeWorkday.Domain.Common.Mappings;
using EmployeeWorkday.Domain.Common.Models;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Employee.Queries.GetEmployeesWithPagination;

public abstract record GetEmployeesWithPaginationQuery : IRequest<PaginatedList<Workday.Queries.GetWorkdaysWithPagination.WorkdayBriefDto>>
{
    public Guid EmployeeId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetWorkdaysWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetEmployeesWithPaginationQuery, PaginatedList<Workday.Queries.GetWorkdaysWithPagination.WorkdayBriefDto>>
{
    public async Task<PaginatedList<Workday.Queries.GetWorkdaysWithPagination.WorkdayBriefDto>> Handle(GetEmployeesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Workdays
            .Where(x => x.Employee.Id == request.EmployeeId)
            .OrderBy(x => x.StartTime)
            .ProjectTo<Workday.Queries.GetWorkdaysWithPagination.WorkdayBriefDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
