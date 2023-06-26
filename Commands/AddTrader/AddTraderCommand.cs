using MediatR;


  public class AddTraderCommand : IRequest<TraderDTO>
  {
    public TraderDTO _trader;
    public AddTraderCommand(TraderDTO trader)
    {
      _trader = trader;
    }
  }
