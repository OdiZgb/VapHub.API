
using Data;
using MediatR;
public class AddShipmentImageCommandHandler : IRequestHandler<AddShipmentImageCommand, ShipmentImageDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddShipmentImageCommandHandler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ShipmentImageDTO> Handle(AddShipmentImageCommand request, CancellationToken cancellationToken)
  {
    if (request._ShipmentImageDTO.file == null || request._ShipmentImageDTO.file.Length == 0)
    {
      return new ShipmentImageDTO();
    }

    var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ShipmentImages");
    if (!Directory.Exists(uploadsFolderPath))
    {
      Directory.CreateDirectory(uploadsFolderPath);
    }
    var name=new Random().Next()+System.IO.Path.GetExtension(request._ShipmentImageDTO.file.FileName);
    var filePath = Path.Combine(uploadsFolderPath,name);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
      await request._ShipmentImageDTO.file.CopyToAsync(stream);
    }

    var relativeUrl = $"/ShipmentImages/{name}";
    ShipmentImage shipmentImage = new ShipmentImage()
    {
      AlterText = request._ShipmentImageDTO.AlterText,
      Id = request._ShipmentImageDTO.Id,
      barcode = request._ShipmentImageDTO.barcode,
      ImageURL = relativeUrl
    };
    _dbContext.ShipmentImage.Add(shipmentImage);
    await _dbContext.SaveChangesAsync(cancellationToken);
    ShipmentImageDTO shipmentImageDTO = new ShipmentImageDTO()
    {
      AlterText = request._ShipmentImageDTO.AlterText,
      Id = request._ShipmentImageDTO.Id,
      barcode= request._ShipmentImageDTO.barcode,
      ImageURL = relativeUrl
    };
    return shipmentImageDTO;
  }
}
