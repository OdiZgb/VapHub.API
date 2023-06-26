using MediatR;

namespace Commands.deleteItem
{
  public class DeleteCategoryCommand : IRequest<bool>
  {
    public int _Id;
     public DeleteCategoryCommand(int Id)
    {
      _Id = Id;
    }
  }
}