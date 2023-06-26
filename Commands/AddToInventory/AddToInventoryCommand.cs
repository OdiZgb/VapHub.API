using MediatR;


  public class AddToInventoryCommand : IRequest<InventoryDTO>
  {
    public InventoryDTO _inventoryDTO;
    public AddToInventoryCommand(InventoryDTO inventoryDTO)
    {
      _inventoryDTO = inventoryDTO;
    }
  }
