using MediatR;

namespace Commands.deleteItem
{
  public class DeleteMarkaCommand : IRequest<bool>
  {
    public int _Id;
     public DeleteMarkaCommand(int Id)
    {
      _Id = Id;
    }
  }
}