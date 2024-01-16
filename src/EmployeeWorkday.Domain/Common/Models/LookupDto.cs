using AutoMapper;
using EmployeeWorkday.Domain.Entities.Employee;
using EmployeeWorkday.Domain.Entities.Workday;

namespace EmployeeWorkday.Domain.Common.Models;

public class LookupDto
{
    public int Id { get; init; }

    public string? Title { get; init; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, LookupDto>();
            CreateMap<WorkDay, LookupDto>();
        }
    }
}
