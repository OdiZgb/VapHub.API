
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllInventoryQueryByBarcodeHandeler : IRequestHandler<GetAllInventoryQueryByBarcodeQuery, IEnumerable<InventoryDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllInventoryQueryByBarcodeHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InventoryDTO>> Handle(GetAllInventoryQueryByBarcodeQuery request, CancellationToken cancellationToken)
    {
        List<Inventory> inventories = await _dbContext.Inventory.Where(x => x.Barcode == request._barcode)
            .Include(e => e.Item).Include(i => i.Item.Category).Include(x => x.Item.itemImages).Include(i => i.Item.Marka).Include(e => e.PriceIn)
            .Include(e => e.Trader).Include(x => x.Employee).ThenInclude(x=>x.User)
            .ToListAsync();
        var a = _mapper.Map<List<InventoryDTO>>(inventories);

        var imagePath = await this._dbContext.ShipmentImage.FirstOrDefaultAsync(x => x.barcode == request._barcode);
        if (imagePath!=null)
        {
            foreach (var x in a)
            {
                x.imagePath = imagePath?.ImageURL;
            }
        }

        return a;
    }
}
