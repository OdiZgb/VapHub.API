using MediatR;


  public class AddEmployeeCommand : IRequest<EmployeeDTO>
  {
    public EmployeeDTO _employee;
    public AddEmployeeCommand(EmployeeDTO employee)
    {
      _employee = employee;
    }
  }
