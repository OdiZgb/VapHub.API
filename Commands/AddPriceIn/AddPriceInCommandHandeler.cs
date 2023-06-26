
using Data;
using MediatR;
public class AddPriceInCommandHandeler : IRequestHandler<AddPriceInCommand, PriceInDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddPriceInCommandHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<PriceInDTO> Handle(AddPriceInCommand request, CancellationToken cancellationToken)
  {
    var priceIn = new PriceIn
    {
      Price = request._priceInDTO.Price,
      ItemId = request._priceInDTO.ItemId
    };
    var price = _dbContext.PriceIn.Add(priceIn);
    await _dbContext.SaveChangesAsync(cancellationToken);
    var Item = _dbContext.Items.FirstOrDefault(x=>x.Id==request._priceInDTO.ItemId);
    Item.PriceIn = price.Entity;
    Item.PriceInId = price.Entity.Id;
    await _dbContext.SaveChangesAsync(cancellationToken);

    return new PriceInDTO
    {
      Price = priceIn.Price,
      ItemId = priceIn.ItemId
    };
  }
}
