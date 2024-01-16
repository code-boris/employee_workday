using AutoMapper;

namespace EmployeeWorkday.Domain.Entities.Workday.Queries.GetWorkdaysWithPagination;

public class WorkdayBriefDto(Employee.Employee employee)
{
    public Employee.Employee Employee { get; init; } = employee;
    
    public DateTime StartTime { get; init; }
    
    public DateTime EndTime { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<WorkDay, WorkdayBriefDto>();
        }
    }
}
