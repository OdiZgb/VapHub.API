using MediatR;


  public class GetAllInventoryQuery : IRequest<IEnumerable<InventoryDTO>>
  {
    public GetAllInventoryQuery()
    {
    }
  }
