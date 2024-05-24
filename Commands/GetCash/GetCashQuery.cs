using MediatR;


  public class GetCashQuery : IRequest<IEnumerable<HistoryOfCashBill>>
  {
    public GetCashQuery()
    {
    }
  }
