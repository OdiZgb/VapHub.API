using MediatR;


  public class GetSalaryQuery : IRequest<SalaryDTO>
  {
    public int employeeId;
    public GetSalaryQuery(int _employeeId)
    {
      employeeId = _employeeId;
    }
  }
