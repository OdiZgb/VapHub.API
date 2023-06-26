using MediatR;


  public class GetItemPriceInQuery : IRequest<PriceInDTO>
  {
    public int itemID;
    public GetItemPriceInQuery(int _itemID)
    {
      itemID = _itemID;
    }
  }
