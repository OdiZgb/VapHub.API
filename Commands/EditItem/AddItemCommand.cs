using MediatR;

  public class EditItemCommand : IRequest<ItemDTO>
  {
    public ItemDTO _itemDTO;
    public EditItemCommand(ItemDTO itemDTO)
    {
      _itemDTO = itemDTO;
    }
  }