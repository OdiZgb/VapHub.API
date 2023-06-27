using MediatR;


  public class GetAllTradersQuery : IRequest<IEnumerable<TraderDTO>>
  {
    public GetAllTradersQuery()
    {
    }
  }
