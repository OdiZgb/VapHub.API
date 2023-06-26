using MediatR;

  public class AddMarkaCommand : IRequest<MarkaDTO>
  {
    public MarkaDTO _markaDTO;
    public AddMarkaCommand(MarkaDTO markaDTO)
    {
      _markaDTO = markaDTO;
    }
  }