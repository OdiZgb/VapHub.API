using Data;
using MediatR;

namespace Commands.deleteItem
{
  public class DeletetemCommandHandeler : IRequestHandler<DeleteItemCommand, bool>
  {
    public AppDbContext _dbContext { set; get; }
    public DeletetemCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
      var item = new Item
      {
        Id=request._Id
      };

      _dbContext.Items.Remove(item);
      await _dbContext.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}