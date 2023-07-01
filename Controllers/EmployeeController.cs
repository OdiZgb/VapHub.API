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
 
    [HttpGet("getEmployee/{employeeId}")]
    public async Task<ActionResult<EmployeeDTO>> getEmployee(int employeeId)
    {
      var query = new GetEmployeeQuery(employeeId);
      var employee = await _mediator.Send(query);
      return Ok(employee);
    }
    
    [HttpGet("getAllEmployees")]
    public async Task<ActionResult<IEnumerable<EmployeeDTO>>> getAllEmployees()
    {
      var query = new GetAllEmployeesQuery();
      var Employees = await _mediator.Send(query);
      return Ok(Employees);
    }
  }