using MediatR;


  public class GetAllSalarysQuery : IRequest<IEnumerable<SalaryDTO>>
  {
    public GetAllSalarysQuery()
    {
    }
  }
