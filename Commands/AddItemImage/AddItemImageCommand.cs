using MediatR;


  public class AddItemImageCommand : IRequest<ItemImageDTO>
  {
    public ItemImageDTO _ItemImageDTO;
    public AddItemImageCommand(ItemImageDTO  ItemImageDTO)
    {
      _ItemImageDTO = ItemImageDTO;
    }
  }
