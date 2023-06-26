
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetItemQueryHandeler : IRequestHandler<GetItemQuery, ItemDTO>
{
  public AppDbContext _dbContext { set; get; }
  public GetItemQueryHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

    async Task<ItemDTO> IRequestHandler<GetItemQuery, ItemDTO>.Handle(GetItemQuery request, CancellationToken cancellationToken)
    {

        Item item =  _dbContext.Items.Include(e => e.itemImages).Include(e => e.Category).Include(c => c.PriceIn).Include(x => x.PriceOut).Include(e => e.Marka).FirstOrDefault(x => x.Id == request.itemId);
        ItemDTO itemDTO = new ItemDTO();

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
         itemDTO = new ItemDTO()
        {
            Barcode = item?.Barcode,
            Id = item.Id,
            Name = item.Name,
            CategoryDTO = categoryDTO,
            MarkaDTO = markaDTO,
            ItemsImageDTOs = itemImageDTO,
            PriceInDTO = new PriceInDTO
            {
                Id = 0, // Set the appropriate value if necessary
                ItemId = 0, // Set the appropriate value if necessary
                Price = item.PriceIn?.Price ?? 0,
                Item = null, // Set the appropriate value if necessary
                Date = default, // Set the appropriate value if necessary
                ExpirationDate = default // Set the appropriate value if necessary
            },
            PriceOutDTO = new PriceOutDTO
            {
                Id = 0, // Set the appropriate value if necessary
                ItemId = 0, // Set the appropriate value if necessary
                Price = item.PriceOut?.Price ?? 0,
                Date = default, // Set the appropriate value if necessary
                ExpirationDate = default // Set the appropriate value if necessary
            }
        };


        return  itemDTO;
    }
 
}