using MediatR;


  public class GetDeletedCashQuery : IRequest<IEnumerable<HistoryOfCashBill>>
  {
    public GetDeletedCashQuery()
    {
    }
  }
