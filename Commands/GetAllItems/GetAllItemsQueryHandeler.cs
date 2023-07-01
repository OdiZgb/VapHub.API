using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllItemsQueryHandeler : IRequestHandler<GetAllItemsQuery, IEnumerable<ItemDTO>>
{
    private readonly IMediator _mediator;
    public AppDbContext _dbContext { set; get; }

    public GetAllItemsQueryHandeler(AppDbContext dbContext, IMediator mediator)
    {
        _mediator = mediator;
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<ItemDTO>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        List<Item> items = await _dbContext.Items.Include(e => e.itemImages).Include(e => e.Category).Include(c => c.PriceIn).Include(x => x.PriceOut).Include(e => e.Marka).ToListAsync();
        List<ItemDTO> itemsDTOs = new List<ItemDTO>();

        foreach (Item item in items)
        {
            List<ItemImageDTO> itemImageDTO = new List<ItemImageDTO>();
            foreach (ItemImage image in item.itemImages)
            {
                itemImageDTO.Add(
                  new ItemImageDTO()
                  {
                      AlterText = image.AlterText,
                      Id = image.Id,
                      ImageURL = image.ImageURL,
                      ItemId = image.ItemId
                  }
                );
            }

            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = item?.Category?.Id,
                Description = item?.Category?.Description,
                Name = item?.Category?.Name
            };

            MarkaDTO markaDTO = new MarkaDTO()
            {
                Id = item?.Marka?.Id,
                Description = item?.Marka?.Description,
                Name = item?.Marka?.Name
            };

            var priceIn = await this._dbContext.PriceIn.FirstOrDefaultAsync(x => x.ItemId == item.Id);

            ItemDTO itemDTO = new ItemDTO()
            {
                Barcode = item?.Barcode,
                Id = item.Id,
                Name = item.Name,
                CategoryDTO = categoryDTO,
                MarkaDTO = markaDTO,
                ItemsImageDTOs = itemImageDTO,
                PriceInDTO = priceIn != null ? new PriceInDTO()
                {
                    Id = priceIn.Id,
                    Date = priceIn.Date,
                    ExpirationDate = priceIn.ExpirationDate,
                    ItemId = priceIn.ItemId,
                    Price = priceIn.Price
                } : null, // Or handle this situation in some other way

                PriceOutDTO = new PriceOutDTO
                {
                    Id = 0, // Set the appropriate value if necessary
                    ItemId = 0, // Set the appropriate value if necessary
                    Price = item.PriceOut?.Price ?? 0,
                    Date = default, // Set the appropriate value if necessary
                    ExpirationDate = default // Set the appropriate value if necessary
                }
            };
            itemsDTOs.Add(itemDTO);
        }

        return itemsDTOs;
    }
}
