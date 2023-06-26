
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetInventoryQueryHandeler : IRequestHandler<GetInventoryQuery, InventoryDTO>
{
  private readonly IMediator _mediator;
  public AppDbContext _dbContext { set; get; }
  public GetInventoryQueryHandeler(AppDbContext dbContext, IMediator mediator)
  {
    _dbContext = dbContext;
    _mediator = mediator;

  }

  public async Task<InventoryDTO> Handle(GetInventoryQuery request, CancellationToken cancellationToken)
  {

    Inventory inventory = _dbContext.Inventory.Where(x => x.Id == request.itemID).FirstOrDefault();
    var query = new GetItemQuery(inventory.ItemId);
    ItemDTO ItemDTO = await _mediator.Send(query);
        
    CategoryDTO categoryDTO = new CategoryDTO()
        {
            Id = inventory.Item?.Category?.Id,
            Description = inventory.Item?.Category?.Description,
            Name = inventory.Item?.Category?.Name
        };
        MarkaDTO markaDTO = new MarkaDTO()
        {
            Id = inventory.Item?.Marka?.Id,
            Description = inventory.Item?.Marka?.Description,
            Name = inventory.Item?.Marka?.Name
        };
        return new InventoryDTO
        {
            ExpirationDate = inventory.ExpirationDate,
            ManufacturingDate = inventory.ManufacturingDate,
            ItemDTO =ItemDTO,
            NumberOfUnits = inventory.NumberOfUnits,
            ArrivalDate = inventory.ArrivalDate,
            PriceInDTO = new PriceInDTO
            {
                Id = 0, // Set the appropriate value if necessary
                ItemId = 0, // Set the appropriate value if necessary
                Price = inventory.Item.PriceIn?.Price ?? 0,
                Item = null, // Set the appropriate value if necessary
                Date = default, // Set the appropriate value if necessary
                ExpirationDate = default // Set the appropriate value if necessary
            },
            PriceInId = inventory.PriceInId
        };
  }
}