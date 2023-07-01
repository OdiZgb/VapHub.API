using MediatR;


  public class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
  {
    public GetAllClientsQuery()
    {
    }
  }
