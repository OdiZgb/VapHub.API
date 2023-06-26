
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddToInventoryCommandHandeler : IRequestHandler<AddToInventoryCommand, InventoryDTO>
{
    public AppDbContext _dbContext { set; get; }
  private readonly IMediator _mediator;
    public AddToInventoryCommandHandeler(AppDbContext dbContext,IMediator mediator)
    {
        _dbContext = dbContext;
    _mediator = mediator;

    }

    public async Task<InventoryDTO> Handle(AddToInventoryCommand request, CancellationToken cancellationToken)
    {
        var Item = _dbContext.Items.Include(x => x.Category).Include(x => x.Marka).Include(x => x.PriceIn).FirstOrDefault(x => x.Id == request._inventoryDTO.ItemId);
        var PriceIn = _dbContext.PriceIn.FirstOrDefault(x => x.Id == request._inventoryDTO.PriceInId);

        var inventory = new Inventory
        {
            ExpirationDate = request._inventoryDTO.ExpirationDate,
            ManufacturingDate = request._inventoryDTO.ManufacturingDate,
            Item = Item,
            NumberOfUnits = request._inventoryDTO.NumberOfUnits,
            ArrivalDate = request._inventoryDTO.ArrivalDate,
            PriceIn = PriceIn,
            PriceInId = request._inventoryDTO.PriceInId,
            PatchId = request._inventoryDTO.PatchId,
            ItemId = request._inventoryDTO.ItemId
        };


        var Inventory = _dbContext.Inventory.Add(inventory);
        await _dbContext.SaveChangesAsync(cancellationToken);

        CategoryDTO categoryDTO = new CategoryDTO()
        {
            Id = Item?.Category?.Id,
            Description = Item?.Category?.Description,
            Name = Item?.Category?.Name
        };
        MarkaDTO markaDTO = new MarkaDTO()
        {
            Id = Item?.Marka?.Id,
            Description = Item?.Marka?.Description,
            Name = Item?.Marka?.Name
        };
        var query = new GetItemQuery((int)inventory.ItemId);
        ItemDTO ItemDTO = await _mediator.Send(query);
        
        return new InventoryDTO
        {
            Id = Inventory.Entity.Id,
            PatchId = Inventory.Entity.PatchId,
            ItemDTO = ItemDTO,
            ItemId = Inventory.Entity.ItemId,
            ExpirationDate = request._inventoryDTO.ExpirationDate,
            ManufacturingDate = request._inventoryDTO.ManufacturingDate,
            NumberOfUnits = request._inventoryDTO?.NumberOfUnits,
            ArrivalDate = Inventory.Entity.ArrivalDate,
            PriceInId = request?._inventoryDTO?.PriceInId
        };
    }
}
