using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeWorkday.Domain.Common.Mappings;
using EmployeeWorkday.Domain.Common.Models;
using EmployeeWorkday.Domain.Interfaces;
using MediatR;

namespace EmployeeWorkday.Domain.Entities.Workday.Queries.GetWorkdaysWithPagination;

public abstract record GetWorkdaysWithPaginationQuery : IRequest<PaginatedList<WorkdayBriefDto>>
{
    public Guid EmployeeId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetWorkdaysWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetWorkdaysWithPaginationQuery, PaginatedList<WorkdayBriefDto>>
{
    public async Task<PaginatedList<WorkdayBriefDto>> Handle(GetWorkdaysWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Workdays
            .Where(x => x.Employee.Id == request.EmployeeId)
            .OrderBy(x => x.StartTime)
            .ProjectTo<WorkdayBriefDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
