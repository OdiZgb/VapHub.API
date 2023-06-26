
using Data;
using MediatR;
using Models;

public class GetItemPriceOutQueryHandeler : IRequestHandler<GetItemPriceOutQuery, PriceOutDTO>
{
  public AppDbContext _dbContext { set; get; }
  public GetItemPriceOutQueryHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<PriceOutDTO> Handle(GetItemPriceOutQuery request, CancellationToken cancellationToken)
  {

    Item item = _dbContext.Items.Where(x => x.Id == request.itemID).FirstOrDefault();
    PriceOutDTO priceInDTO = new PriceOutDTO()
    {
      Price = item.PriceOut.Price,
      Id = item.PriceOut.Id
    };
      return priceInDTO;
  }
}