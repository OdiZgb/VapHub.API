
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetAllInventoryQueryHandeler : IRequestHandler<GetAllInventoryQuery, IEnumerable<InventoryDTO>>
{
  public AppDbContext _dbContext { set; get; }
  private readonly IMediator _mediator;
  public GetAllInventoryQueryHandeler(AppDbContext dbContext, IMediator mediator)
  {
    _dbContext = dbContext;
    _mediator = mediator;
  }

  public async Task<IEnumerable<InventoryDTO>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
  {

    List<Inventory> inventories = await _dbContext.Inventory.Include(e => e.Item).Include(e => e.PriceIn).Include(c=>c.Item.Category).Include(x=>x.Item.Marka).ToListAsync();
    List<InventoryDTO> inventoryDTOs = new List<InventoryDTO>();
    foreach (Inventory inventory in inventories)
    {
      var query = new GetItemQuery(inventory.ItemId);
    ItemDTO ItemDTO = await _mediator.Send(query);
        
      CategoryDTO categoryDTO = new CategoryDTO() {
        Id = inventory.Item?.Category?.Id,
        Description = inventory.Item?.Category?.Description,
        Name = inventory.Item?.Category?.Name
      };
      MarkaDTO markaDTO = new MarkaDTO() {
        Id = inventory.Item?.Marka?.Id,
        Description = inventory.Item?.Marka?.Description,
        Name = inventory.Item?.Marka?.Name
      };
      
      InventoryDTO inventoryDTO = new InventoryDTO(){
NumberOfUnits = inventory.NumberOfUnits,
            ArrivalDate = inventory.ArrivalDate,
            PriceInDTO = new PriceInDTO
            {
                Id = 0, // Set the appropriate value if necessary
                ItemId = 0, // Set the appropriate value if necessary
                Price = inventory.PriceIn?.Price ?? 0,
                Date = default, // Set the appropriate value if necessary
                ExpirationDate = default // Set the appropriate value if necessary
            },
            PriceInId = inventory.Item.PriceInId,
            ItemDTO = ItemDTO,
            ExpirationDate = inventory.ExpirationDate,
            ItemId = ItemDTO.Id,
            Id = inventory.Id,
            ManufacturingDate = inventory.ManufacturingDate,
            PatchId = inventory.PatchId,
            

        
      };
      inventoryDTOs.Add(inventoryDTO);
    }
    return inventoryDTOs;
  }
}