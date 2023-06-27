using MediatR;


  public class GetTraderQuery : IRequest<TraderDTO>
  {
    public int traderId;
    public GetTraderQuery(int _traderId)
    {
      traderId = _traderId;
    }
  }
