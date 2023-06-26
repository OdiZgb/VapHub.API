using MediatR;


  public class AddPriceOutCommand : IRequest<PriceOutDTO>
  {
    public PriceOutDTO _priceOutDTO;
    public AddPriceOutCommand(PriceOutDTO priceOutDTO)
    {
      _priceOutDTO = priceOutDTO;
    }
  }
