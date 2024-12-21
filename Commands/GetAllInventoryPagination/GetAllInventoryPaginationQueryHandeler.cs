
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllInventoryPaginationQueryHandeler : IRequestHandler<GetAllInventoryPaginationQuery, IEnumerable<InventoryDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllInventoryPaginationQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

public async Task<IEnumerable<InventoryDTO>> Handle(GetAllInventoryPaginationQuery request, CancellationToken cancellationToken)
{
    var inventories = await _dbContext.Inventory
        .Include(e => e.Item)
        .Include(i => i.Item.Category)
        .Include(i => i.Item.Marka)
        .Include(e => e.PriceIn)
        .Include(e => e.Trader)
        .Include(x => x.Employee).ThenInclude(x => x.User)
        .Skip((request.PageNumber - 1) * request.PageSize)
        .Take(request.PageSize)
        .ToListAsync();

    return _mapper.Map<List<InventoryDTO>>(inventories);
}


}