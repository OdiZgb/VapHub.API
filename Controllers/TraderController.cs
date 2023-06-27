using MediatR;
using Microsoft.AspNetCore.Mvc;



  [Route("price")]
  [ApiController]
  public class TraderController : ControllerBase
  {
    private readonly IMediator _mediator;
    public TraderController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("addTrader")]
    public async Task<ActionResult<TraderDTO>> addTrader([FromBody] TraderDTO traderDTO)
    {
      var command = new AddTraderCommand(traderDTO);
      var trader = await _mediator.Send(command);
      return Ok(trader);
    }
 
    [HttpGet("getTrader/{traderId}")]
    public async Task<ActionResult<TraderDTO>> getTrader(int traderId)
    {
      var query = new GetTraderQuery(traderId);
      var trader = await _mediator.Send(query);
      return Ok(trader);
    }
    
    [HttpGet("getAllTraders")]
    public async Task<ActionResult<IEnumerable<TraderDTO>>> getAllTraders()
    {
      var query = new GetAllTradersQuery();
      var Traders = await _mediator.Send(query);
      return Ok(Traders);
    }
  }