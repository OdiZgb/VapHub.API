
using Data;
using MediatR;
public class AddPriceOutCommandHandeler : IRequestHandler<AddPriceOutCommand, PriceOutDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddPriceOutCommandHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<PriceOutDTO> Handle(AddPriceOutCommand request, CancellationToken cancellationToken)
  {
    var priceOut = new PriceOut
    {
      Price = request._priceOutDTO.Price,
      ItemId = request._priceOutDTO.ItemId
    };

    var price = _dbContext.PriceOut.Add(priceOut);
    await _dbContext.SaveChangesAsync(cancellationToken);
    var Item = _dbContext.Items.FirstOrDefault(x=>x.Id==request._priceOutDTO.ItemId);
    Item.PriceOut = price.Entity;
    Item.PriceOutId = price.Entity.Id;
    await _dbContext.SaveChangesAsync(cancellationToken);

    return new PriceOutDTO
    {
      Price = priceOut.Price,
      ItemId = priceOut.ItemId
    };
  }
}
