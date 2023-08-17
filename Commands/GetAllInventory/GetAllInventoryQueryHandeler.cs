
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllInventoryQueryHandeler : IRequestHandler<GetAllInventoryQuery, IEnumerable<InventoryDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllInventoryQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InventoryDTO>> Handle(GetAllInventoryQuery request, CancellationToken cancellationToken)
    {
        List<Inventory> inventories = await _dbContext.Inventory
            .Include(e => e.Item).Include(i => i.Item.Category).Include(i => i.Item.Marka).Include(e => e.PriceIn)
            .Include(e => e.Trader).Include(x=>x.Employee).ThenInclude(x=>x.User)
            .ToListAsync();
            var a =_mapper.Map<List<InventoryDTO>>(inventories);
        return a;
    }
}