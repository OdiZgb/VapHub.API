
using Data;
using MediatR;
public class AddTagItemCommandHandeler : IRequestHandler<AddTagItemCommand, TagItemDTO>
{
  public AppDbContext _dbContext { set; get; }
  public AddTagItemCommandHandeler(AppDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<TagItemDTO> Handle(AddTagItemCommand request, CancellationToken cancellationToken)
  {
    var TagItem = new TagItem
    {
      TagId = request._tagItemDTO.TagId,
      ItemId = request._tagItemDTO.ItemId
    };
    var tagItem = _dbContext.TagItems.Add(TagItem);
    await _dbContext.SaveChangesAsync(cancellationToken);
    await _dbContext.SaveChangesAsync(cancellationToken);

    return new TagItemDTO
    {
      TagId = TagItem.Id,
      ItemId = TagItem.ItemId
    };
  }
}
