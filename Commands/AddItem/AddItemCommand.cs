using MediatR;

  public class AddItemCommand : IRequest<ItemDTO>
  {
    public ItemDTO _itemDTO;
    public AddItemCommand(ItemDTO itemDTO)
    {
      _itemDTO = itemDTO;
    }
  }