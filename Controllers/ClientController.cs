using MediatR;
using Microsoft.AspNetCore.Mvc;

  [Route("client")]
  [ApiController]
  public class ClientController : ControllerBase
  {
    private readonly IMediator _mediator;
    public ClientController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("addClient")]
    public async Task<ActionResult<ClientDTO>> addClient([FromBody] ClientDTO clientDTO)
    {
      var command = new AddClientCommand(clientDTO);
      var client = await _mediator.Send(command);
      return Ok(client);
    }
 
    [HttpGet("getClient/{clientId}")]
    public async Task<ActionResult<ClientDTO>> getClient(int clientId)
    {
      var query = new GetClientQuery(clientId);
      var client = await _mediator.Send(query);
      return Ok(client);
    }
    
    [HttpGet("getAllClients")]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> getAllClients()
    {
      var query = new GetAllClientsQuery();
      var Clients = await _mediator.Send(query);
      return Ok(Clients);
    }
  }