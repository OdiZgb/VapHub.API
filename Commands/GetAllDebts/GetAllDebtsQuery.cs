using MediatR;


  public class GetAllClientDebtsQuery : IRequest<IEnumerable<ClientDebtDTO>>
  {
    public GetAllClientDebtsQuery()
    {
    }
  }
