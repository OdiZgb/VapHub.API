using MediatR;


  public class CompleteDebtCommand : IRequest<ClientDebtDTO>
  {
    public int _id;
    public CompleteDebtCommand(int id)
    {
      _id= id;
    }
  }
