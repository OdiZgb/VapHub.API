using MediatR;


  public class GetClientQuery : IRequest<ClientDTO>
  {
    public int clientId;
    public GetClientQuery(int _clientId)
    {
      clientId = _clientId;
    }
  }
