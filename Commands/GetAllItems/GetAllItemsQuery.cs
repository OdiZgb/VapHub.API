using MediatR;


  public class GetAllItemsQuery : IRequest<IEnumerable<ItemDTO>>
  {
    public GetAllItemsQuery()
    {
    }
  }
