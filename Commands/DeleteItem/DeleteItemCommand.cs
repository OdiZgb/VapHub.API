using MediatR;

namespace Commands.deleteItem
{
  public class DeleteItemCommand : IRequest<bool>
  {
    public int _Id;
     public DeleteItemCommand(int Id)
    {
      _Id = Id;
    }
  }
}