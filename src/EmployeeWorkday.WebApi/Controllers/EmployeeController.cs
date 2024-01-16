using EmployeeWorkday.Domain.Entities.Employee;
using EmployeeWorkday.Mediator;
using EmployeeWorkday.WebApi.UseCases.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeWorkday.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController(IApplicationMediator mediator) : ControllerBase
{
    [HttpGet("GetAll")]
    public IActionResult GetAllEmployees()
    {
        var employees = mediator.Send<EmployeeRequest, IReadOnlyCollection<Employee>>(new EmployeeRequest());
        return Ok(employees);
    }

    [HttpGet("{id:guid}", Name = "Get")]
    public IActionResult GetEmployeeById(Guid id)
    {
        var employeeRequest = new EmployeeRequest { Id = id };
        var employee = mediator.Send<EmployeeRequest, Employee>(employeeRequest);

        if (employee == null)
        {
            return NotFound();
        }

        return Ok(employee);
    }

    [HttpPost(Name = "Create")]
    public IActionResult CreateEmployee([FromBody] Employee? employee)
    {
        if (employee == null)
        {
            return BadRequest("Invalid employee data");
        }

        var createEmployeeRequest = new CreateEmployeeRequest
        {
            Name = employee.Name,
            EmployeeNumber = employee.EmployeeNumber
        };

        var createdEmployee = mediator.Send<CreateEmployeeRequest, Employee>(createEmployeeRequest);

        return CreatedAtAction(nameof(GetEmployeeById), new { id = createdEmployee.Id }, createdEmployee);
    }

    [HttpPut("{id:guid}", Name = "Update")]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] Employee? updatedEmployee)
    {
        if (updatedEmployee == null)
        {
            return BadRequest("Invalid employee data");
        }

        var existingEmployeeRequest = new EmployeeRequest { Id = id };
        var existingEmployee = await mediator.Send<EmployeeRequest, Employee>(existingEmployeeRequest);

        if (existingEmployee == null)
        {
            return NotFound();
        }

        existingEmployee.Name = updatedEmployee.Name;
        existingEmployee.EmployeeNumber = updatedEmployee.EmployeeNumber;
            
        var updateEmployeeRequest = new UpdateEmployeeRequest
        {
            Name = existingEmployee.Name,
            EmployeeNumber = existingEmployee.EmployeeNumber,
            WorkDays = existingEmployee.WorkDays
        };

        await mediator.Send<UpdateEmployeeRequest, Unit>(updateEmployeeRequest);

        return Ok(existingEmployee);
    }

    [HttpDelete("{id:guid}", Name = "Delete")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var employeeRequest = new EmployeeRequest { Id = id };
        var existingEmployee = await mediator.Send<EmployeeRequest, Employee>(employeeRequest);

        if (existingEmployee == null)
        {
            return NotFound();
        }

        var deleteEmployeeRequest = new DeleteEmployeeRequest { Id = existingEmployee.Id };

        await mediator.Send<DeleteEmployeeRequest, Unit>(deleteEmployeeRequest);

        return NoContent();
    }
}