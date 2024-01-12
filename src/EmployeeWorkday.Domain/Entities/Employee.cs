namespace EmployeeWorkday.Domain.Model;

/// <summary>
/// Сотрудник
/// </summary>
public class Employee
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Имя сотрудника
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Табельный номер сотрудника
    /// </summary>
    public int EmployeeId { get; set; }
}