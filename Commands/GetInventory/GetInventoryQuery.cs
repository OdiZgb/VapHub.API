using MediatR;


  public class GetInventoryQuery : IRequest<InventoryDTO>
  {
    public int itemID;
    public GetInventoryQuery(int _itemID)
    {
      itemID = _itemID;
    }
  }
