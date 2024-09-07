using MediatR;

public class EditInventoryQuantityCommand : IRequest<InventoryDTO>
{
    public int Id { get; set; }
    public UpdateInventoryQuantityDTO QuantityDTO { get; set; }

    public EditInventoryQuantityCommand(int id, UpdateInventoryQuantityDTO quantityDTO)
    {
        Id = id;
        QuantityDTO = quantityDTO;
    }
}
