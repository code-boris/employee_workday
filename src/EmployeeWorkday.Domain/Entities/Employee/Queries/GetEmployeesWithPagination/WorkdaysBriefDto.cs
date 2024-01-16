using AutoMapper;

namespace EmployeeWorkday.Domain.Entities.Employee.Queries.GetEmployeesWithPagination;

public class EmployeeBriefDto(Employee employee)
{
    public Employee Employee { get; init; } = employee;
    
    public DateTime StartTime { get; init; }
    
    public DateTime EndTime { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, EmployeeBriefDto>();
        }
    }
}
