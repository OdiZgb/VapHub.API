
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models;

public class GetItemPriceInQueryHandeler : IRequestHandler<GetItemPriceInQuery, PriceInDTO>
{
  public AppDbContext _dbContext { set; get; }
  public GetItemPriceInQueryHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<PriceInDTO> Handle(GetItemPriceInQuery request, CancellationToken cancellationToken)
  {

    Item item = _dbContext.Items.Where(x => x.Id == request.itemID).FirstOrDefault();
    PriceInDTO priceInDTO = new PriceInDTO()
    {
      Price = item.PriceIn.Price,
      Id = item.PriceIn.Id
    };
      return priceInDTO;
  }
}