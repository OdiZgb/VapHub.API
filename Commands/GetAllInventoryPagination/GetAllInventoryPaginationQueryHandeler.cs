using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllInventoryPaginationQueryHandeler : IRequestHandler<GetAllInventoryPaginationQuery, IEnumerable<InventoryDTO>>
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }

    public GetAllInventoryPaginationQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InventoryDTO>> Handle(GetAllInventoryPaginationQuery request, CancellationToken cancellationToken)
    {
        // Fetch Inventory data without including Tags in EF query
        List<Inventory> inventories = await _dbContext.Inventory
            .Include(e => e.Item)
            .Include(i => i.Item.Category)
            .Include(i => i.Item.Marka)
            .Include(e => e.PriceIn)
            .Include(e => e.Trader)
            .Include(x => x.Employee).ThenInclude(x => x.User)
            .OrderByDescending(x => x.Id)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        List<InventoryDTO> inventoryDTOs = _mapper.Map<List<InventoryDTO>>(inventories);

        // Fetch all tags for later use
        List<Tag> tags = await _dbContext.Tags.ToListAsync();

        foreach (var inventoryDTO in inventoryDTOs)
        {
            // Manually map Tags
            inventoryDTO.ItemDTO.TagsDTO = new List<TagDTO>(); // Initialize the TagsDTO list

            var tagItems = await _dbContext.TagItems.Where(x => x.ItemId == inventoryDTO.ItemDTO.Id).ToListAsync();
            foreach (var tagItem in tagItems)
            {
                Tag tagInItem = tags.FirstOrDefault(x => x.Id == tagItem.TagId);
                if (tagInItem != null)
                {
                    inventoryDTO.ItemDTO.TagsDTO.Add(new TagDTO
                    {
                        Id = tagInItem.Id,
                        Title = tagInItem.Title
                    });
                }
            }
        }

        return inventoryDTOs;
    }
}
