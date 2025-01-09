
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetCurrentQuantitesQueryHandeler : IRequestHandler<GetCurrentQuantitesQuery, IEnumerable<ItemQuantityDTO>>
{
    private readonly IMediator _mediator;
    public AppDbContext _dbContext { set; get; }
    public GetCurrentQuantitesQueryHandeler(AppDbContext dbContext, IMediator mediator)
    {
        _dbContext = dbContext;
        _mediator = mediator;

    }

    public async Task<IEnumerable<ItemQuantityDTO>> Handle(GetCurrentQuantitesQuery request, CancellationToken cancellationToken)
    {
        List<ItemQuantityDTO> quantites = new List<ItemQuantityDTO>();
        List<Item> items = _dbContext.Items.ToList();
        
        foreach (var item in items)
        {
            List<Inventory> inventory = _dbContext.Inventory.Where(x => x.ItemId == item.Id).ToList();
            int  numberOfSalesForAnItem = _dbContext.HistoryOfCashBill.Where(x=>x.ItemId == item.Id && x.SoftDeleted!=1).ToList().Count();
            int numberOfRefunds = _dbContext.HistoryOfCashBill.Where(x=>x.ItemId == item.Id && x.SoftDeleted!=1&&  x.IsRefund==1).ToList().Count();
            int q = numberOfRefunds-numberOfSalesForAnItem;

            foreach (var itemIninventory in inventory)
            {
                q = (int)(q + itemIninventory?.NumberOfUnits + numberOfRefunds);
            }

            ItemDTO itemDTO = new ItemDTO()
            {
                Barcode = item?.Barcode,
                Id = item.Id,
                Name = item.Name,
                PriceOutDTO = new PriceOutDTO
                {
                    Id = 0, // Set the appropriate value if necessary
                    ItemId = 0, // Set the appropriate value if necessary
                    Price = item.PriceOut?.Price ?? 0,
                    Date = default, // Set the appropriate value if necessary
                    ExpirationDate = default // Set the appropriate value if necessary
                }
            };

                
                ItemQuantityDTO itemQuantityDTO = new ItemQuantityDTO
                {
                    ItemDTO = itemDTO,
                    Quantity = q
                };


            quantites.Add(itemQuantityDTO);

        }
        return quantites;
    }
}