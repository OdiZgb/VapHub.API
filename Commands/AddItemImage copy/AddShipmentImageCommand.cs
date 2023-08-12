using MediatR;


  public class AddShipmentImageCommand : IRequest<ShipmentImageDTO>
  {
    public ShipmentImageDTO _ShipmentImageDTO;
    public AddShipmentImageCommand(ShipmentImageDTO  ShipmentImageDTO)
    {
      _ShipmentImageDTO = ShipmentImageDTO;
    }
  }
