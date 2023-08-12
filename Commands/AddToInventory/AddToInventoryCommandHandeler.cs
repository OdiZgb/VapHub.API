
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddToInventoryCommandHandeler : IRequestHandler<AddToInventoryCommand, List<InventoryDTO>>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;

    private readonly IMediator _mediator;
    public AddToInventoryCommandHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<List<InventoryDTO>> Handle(AddToInventoryCommand request, CancellationToken cancellationToken)
    {
        List<InventoryDTO> inventoryDTOs= new List<InventoryDTO>();

        var Items = await _dbContext.Items.Include(x => x.Category).Include(x => x.Marka).Include(x => x.PriceIn).ToListAsync();
        var Traders = await _dbContext.Traders.ToListAsync();
        var Employees = await _dbContext.Employees.ToListAsync();

        string intendedNewBarcode = ("" + (Int16.Parse(_dbContext.Inventory.ToList().MaxBy(x => x.Barcode)?.Barcode ?? "000") + 1)).PadLeft(3, '0');

        foreach (var inv in request._inventoryDTOs)
        {
            var Item = Items.FirstOrDefault(x => x.Id == inv.ItemId);
            var Trader = Traders.FirstOrDefault(x => x.Id == inv.TraderId);
            var Employee = Employees.FirstOrDefault(x => x.Id == inv.EmployeeId);
            
            inv.Barcode = intendedNewBarcode;
            var invDB = new Inventory(){
                ArrivalDate= inv.ArrivalDate,
                Barcode = inv.Barcode,
                Employee = Employee,
                EmployeeId = inv.EmployeeId,
                ExpirationDate = inv.ExpirationDate,
                Item= Item,
                ItemId = inv.ItemId,
                ManufacturingDate = inv.ManufacturingDate,
                NumberOfUnits = inv.NumberOfUnits,
                PatchId = inv.PatchId,
                Trader = Trader,
                PriceIn = Item.PriceIn,
                PriceInId = Item.PriceInId,
                TraderId = Trader.Id,
            };
            var inventory = await _dbContext.Inventory.AddAsync(invDB);
            await _dbContext.SaveChangesAsync(cancellationToken);

            inventoryDTOs.Add(_mapper.Map<InventoryDTO>(inventory.Entity));
        }
        return inventoryDTOs;
    }
}
