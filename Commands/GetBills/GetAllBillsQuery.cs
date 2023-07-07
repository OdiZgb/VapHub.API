using MediatR;


  public class GetAllBillsQuery : IRequest<IEnumerable<BillDTO>>
  {
    public GetAllBillsQuery()
    {
    }
  }
