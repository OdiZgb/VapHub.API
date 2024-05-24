using MediatR;

namespace Commands.deleteItem
{
  public class DeleteCashBillCommand : IRequest<bool>
  {
    public int _Id;
     public DeleteCashBillCommand(int Id)
    {
      _Id = Id;
    }
  }
}