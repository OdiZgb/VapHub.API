using MediatR;


  public class AddPriceInCommand : IRequest<PriceInDTO>
  {
    public PriceInDTO _priceInDTO;
    public AddPriceInCommand(PriceInDTO priceInDTO)
    {
      _priceInDTO = priceInDTO;
    }
  }
