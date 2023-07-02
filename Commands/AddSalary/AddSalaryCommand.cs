using MediatR;


  public class AddSalaryCommand : IRequest<SalaryDTO>
  {
    public SalaryDTO _salary;
    public AddSalaryCommand(SalaryDTO salary)
    {
      _salary = salary;
    }
  }
