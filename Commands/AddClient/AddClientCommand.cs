using MediatR;


  public class AddClientCommand : IRequest<ClientDTO>
  {
    public ClientDTO _client;
    public AddClientCommand(ClientDTO client)
    {
      _client = client;
    }
  }
