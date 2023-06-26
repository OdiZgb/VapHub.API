
using Data;
using MediatR;
public class AddTraderCommandHandeler : IRequestHandler<AddTraderCommand, TraderDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddTraderCommandHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<TraderDTO> Handle(AddTraderCommand request, CancellationToken cancellationToken)
  {
    var trader = new Trader
    {
      Email = request._trader.Email,
      Inventories = request._trader.Inventories,
      MobileNumber = request._trader.MobileNumber,
      Name = request._trader.Name,
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
