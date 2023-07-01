
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddToInventoryCommandHandeler : IRequestHandler<AddToInventoryCommand, InventoryDTO>
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

    public async Task<InventoryDTO> Handle(AddToInventoryCommand request, CancellationToken cancellationToken)
    {
        var Item = _dbContext.Items.Include(x => x.Category).Include(x => x.Marka).Include(x => x.PriceIn).FirstOrDefault(x => x.Id == request._inventoryDTO.ItemId);
        var PriceIn = _dbContext.PriceIn.FirstOrDefault(x => x.Id == request._inventoryDTO.PriceInId);
        var Trader = _dbContext.Traders.FirstOrDefault(x => x.Id == request._inventoryDTO.TraderId);

        var inventory = _mapper.Map<Inventory>(request._inventoryDTO);


        var Inventory = _dbContext.Inventory.Add(inventory);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<InventoryDTO>(inventory);
    }
}
