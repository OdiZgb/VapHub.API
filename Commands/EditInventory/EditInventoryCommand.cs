using MediatR;
using System.Collections.Generic;

public class EditInventoryCommand : IRequest<InventoryDTO>
{
    public int Id { get; set; }
    public InventoryDTO InventoryDTO { get; set; }

    public EditInventoryCommand(int id, InventoryDTO inventoryDTO)
    {
        Id = id;
        InventoryDTO = inventoryDTO;
    }
}
