using Commands.deleteItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;



[Route("marka")]
[ApiController]
public class MarkaController : ControllerBase
{
  private readonly IMediator _mediator;
  public MarkaController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("addMarka")]
  public async Task<ActionResult<MarkaDTO>> addMarka(MarkaDTO markaDTO)
  {
    var command = new AddMarkaCommand(markaDTO);
    var markas = await _mediator.Send(command);
    return Ok(markas);
  }

  [HttpGet("getAllMarkas")]
  public async Task<ActionResult<IEnumerable<MarkaDTO>>> getAllMarkas()
  {
    var query = new GetAllMarkasQuery();
    var markas = await _mediator.Send(query);
    return Ok(markas);
  }
}