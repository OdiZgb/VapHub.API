using MediatR;


  public class AddToInventoryCommand : IRequest<List<InventoryDTO>>
  {
    public List<InventoryDTO> _inventoryDTOs;
    public AddToInventoryCommand(List<InventoryDTO> inventoryDTOs)
    {
      _inventoryDTOs = inventoryDTOs;
    }
  }
