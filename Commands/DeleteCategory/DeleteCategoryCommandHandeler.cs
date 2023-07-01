using Data;
using MediatR;

namespace Commands.deleteItem
{
  public class DeleteCategoryCommandHandeler : IRequestHandler<DeleteCategoryCommand, bool>
  {
    public AppDbContext _dbContext { set; get; }
    public DeleteCategoryCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
      var category = new Category
      {
        Id=request._Id
      };

      _dbContext.Category.Remove(category);
      await _dbContext.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}