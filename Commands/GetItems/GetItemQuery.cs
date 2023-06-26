using MediatR;


  public class GetItemQuery : IRequest<ItemDTO>
  {
    public int itemId ;

    public GetItemQuery( int _itemId)
    {
      itemId  = _itemId;
    }
  }
