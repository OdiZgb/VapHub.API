using Data;
using MediatR;

  public class AddItemCommandHandeler : IRequestHandler<AddItemCommand, ItemDTO>
  {
    public AppDbContext _dbContext { set; get; }
    public AddItemCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<ItemDTO> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
      Category category =  _dbContext.Category.FirstOrDefault(x=>x.Id==request._itemDTO.CategoryDTO.Id);
      Marka marka =  _dbContext.Marka.FirstOrDefault(x=>x.Id==request._itemDTO.MarkaDTO.Id);
      var item = new Item
      {
        Name = request._itemDTO.Name,
        Barcode = request._itemDTO.Barcode,
        Category = category,
        Marka = marka
      };

      _dbContext.Items.Add(item);
        var saveResult = await _dbContext.SaveChangesAsync(cancellationToken);


      return new ItemDTO
      {
        Id = item.Id,
        Name = item.Name,
        Barcode = item.Barcode
      };
    }
  }