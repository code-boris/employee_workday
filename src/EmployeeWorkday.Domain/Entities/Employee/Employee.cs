using System.ComponentModel.DataAnnotations.Schema;
using EmployeeWorkday.Domain.Common;
using EmployeeWorkday.Domain.Entities.Workday;

namespace EmployeeWorkday.Domain.Entities.Employee;

/// <summary>
/// Сотрудник
/// </summary>
public class Employee(string name) : BaseAuditableEntity
{
    public List<WorkDay> WorkDays { get; set; } = new List<WorkDay>();
    
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Табельный номер сотрудника
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int EmployeeNumber { get; set; } = 0;
}
