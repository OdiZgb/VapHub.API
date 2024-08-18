using Data;
using MediatR;

namespace Commands.deleteItem
{
  public class DeleteMarkaCommandHandeler : IRequestHandler<DeleteMarkaCommand, bool>
  {
    public AppDbContext _dbContext { set; get; }
    public DeleteMarkaCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<bool> Handle(DeleteMarkaCommand request, CancellationToken cancellationToken)
    {
      var marka = new Marka
      {
        Id=request._Id
      };

      _dbContext.Marka.Remove(marka);
      await _dbContext.SaveChangesAsync(cancellationToken);

      return true;
    }
  }
}