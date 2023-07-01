using MediatR;


  public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDTO>>
  {
    public GetAllEmployeesQuery()
    {
    }
  }
