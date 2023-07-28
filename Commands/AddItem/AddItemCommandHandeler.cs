using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddItemCommandHandeler : IRequestHandler<AddItemCommand, ItemDTO>
  {
    public AppDbContext _dbContext { set; get; }
    public AddItemCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<ItemDTO> Handle(AddItemCommand request, CancellationToken cancellationToken)
    {
      List<Item> items = await _dbContext.Items.ToListAsync();
      Category category =  await _dbContext.Category.FirstOrDefaultAsync(x=>x.Id==request._itemDTO.CategoryDTO.Id);
      Marka marka =  await _dbContext.Marka.FirstOrDefaultAsync(x=>x.Id==request._itemDTO.MarkaDTO.Id);
      int greatesBarcode = 0;
      foreach (var barcodeOfItem in items)
      {
        int id = Int16.Parse(barcodeOfItem.Barcode);
        if(id >greatesBarcode){
          greatesBarcode = id;
        }
      }
      string intendedNewBarcode =  (""+(greatesBarcode + 1)).PadLeft(3,'0');

     
      var item = new Item
      {
        Name = request._itemDTO.Name,
        Barcode = intendedNewBarcode,
        Category = category,
        Marka = marka
      };

      _dbContext.Items.Add(item);
        var saveResult = await _dbContext.SaveChangesAsync(cancellationToken);


      return new ItemDTO
      {
        Id = item.Id,
        Name = item.Name,
        Barcode = intendedNewBarcode
      };
    }
  }