using MediatR;


  public class GetEmployeeQuery : IRequest<EmployeeDTO>
  {
    public int employeeId;
    public GetEmployeeQuery(int _employeeId)
    {
      employeeId = _employeeId;
    }
  }
