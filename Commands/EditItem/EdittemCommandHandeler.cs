using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class EditItemCommandHandeler : IRequestHandler<EditItemCommand, ItemDTO>
  {
    public AppDbContext _dbContext { set; get; }
    public EditItemCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

   public async Task<ItemDTO> Handle(EditItemCommand request, CancellationToken cancellationToken)
{
  if (request?._itemDTO == null)
  {
    throw new ArgumentException("Request or ItemDTO is null", nameof(request));
  }

  Item item = await _dbContext.Items.FirstOrDefaultAsync(x => x.Id == request._itemDTO.Id);
  Category category = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == request._itemDTO.CategoryDTO.Id);
  Marka marka = await _dbContext.Marka.FirstOrDefaultAsync(x => x.Id == request._itemDTO.MarkaDTO.Id);

  if (item == null)
  {
    throw new InvalidOperationException($"No item found with ID {request._itemDTO.Id}");
  }

  if (category == null)
  {
    throw new InvalidOperationException($"No category found with ID {request._itemDTO.CategoryDTO.Id}");
  }

  if (marka == null)
  {
    throw new InvalidOperationException($"No marka found with ID {request._itemDTO.MarkaDTO.Id}");
  }

  item.Name = request._itemDTO.Name;
  item.Category = category;
  item.Marka = marka;

  await _dbContext.SaveChangesAsync(cancellationToken);

  return new ItemDTO
  {
    Id = item.Id,
    Name = item.Name,
    Barcode = item.Barcode
  };
}

  }