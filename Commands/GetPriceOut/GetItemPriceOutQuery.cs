using MediatR;


  public class GetItemPriceOutQuery : IRequest<PriceOutDTO>
  {
    public int itemID;
    public GetItemPriceOutQuery(int itemID)
    {
      itemID = itemID;
    }
  }
