using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("addEmployee")]
    public async Task<ActionResult<EmployeeDTO>> addEmployee([FromBody] EmployeeDTO employeeDTO)
    {
        var command = new AddEmployeeCommand(employeeDTO);
        var employee = await _mediator.Send(command);
        return Ok(employee);
    }
    [HttpPost("addSalary")]
    public async Task<ActionResult<EmployeeDTO>> addSalary([FromBody] SalaryDTO salaryDTO)
    {
        var command = new AddSalaryCommand(salaryDTO);
        var salary = await _mediator.Send(command);
        return Ok(salary);
    }

    [HttpGet("getEmployee/{employeeId}")]
    public async Task<ActionResult<EmployeeDTO>> getEmployee(int employeeId)
    {
        var query = new GetEmployeeQuery(employeeId);
        var employee = await _mediator.Send(query);
        return Ok(employee);
    }

    [HttpGet("getEmployeeSalary/{employeeId}")]
    public async Task<ActionResult<SalaryDTO>> getEmployeeSalary(int employeeId)
    {
        var query = new GetSalaryQuery(employeeId);
        var salary = await _mediator.Send(query);
        return Ok(salary);
    }

    [HttpGet("getAllEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> getAllEmployees()
    {
        var query = new GetAllEmployeesQuery();
        var Employees = await _mediator.Send(query);
        return Ok(Employees);
    }

    [HttpGet("getAllSalaries")]
    public async Task<ActionResult<IEnumerable<SalaryDTO>>> getAllSalaries()
    {
        var query = new GetAllSalarysQuery();
        var Salaries = await _mediator.Send(query);
        return Ok(Salaries);
    }
}