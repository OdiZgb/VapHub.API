
using Data;
using MediatR;
public class AddItemImageCommandHandler : IRequestHandler<AddItemImageCommand, ItemImageDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddItemImageCommandHandler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<ItemImageDTO> Handle(AddItemImageCommand request, CancellationToken cancellationToken)
  {
    if (request._ItemImageDTO.file == null || request._ItemImageDTO.file.Length == 0)
    {
      return new ItemImageDTO();
    }

    var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ItemImages");
    if (!Directory.Exists(uploadsFolderPath))
    {
      Directory.CreateDirectory(uploadsFolderPath);
    }
    var name=new Random().Next()+System.IO.Path.GetExtension(request._ItemImageDTO.file.FileName);
    var filePath = Path.Combine(uploadsFolderPath,name);
    using (var stream = new FileStream(filePath, FileMode.Create))
    {
      await request._ItemImageDTO.file.CopyToAsync(stream);
    }

    var relativeUrl = $"/ItemImages/{name}";
    ItemImage itemImage = new ItemImage()
    {
      AlterText = request._ItemImageDTO.AlterText,
      ItemId = request._ItemImageDTO.ItemId,
      ImageURL = relativeUrl
    };
    _dbContext.ItemsImages.Add(itemImage);
    await _dbContext.SaveChangesAsync(cancellationToken);
    ItemImageDTO itemImageDTO = new ItemImageDTO()
    {
      AlterText = request._ItemImageDTO.AlterText,
      ItemId = request._ItemImageDTO.ItemId,
      ImageURL = relativeUrl
    };
    return itemImageDTO;
  }
}
