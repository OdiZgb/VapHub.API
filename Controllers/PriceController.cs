using MediatR;
using Microsoft.AspNetCore.Mvc;



  [Route("price")]
  [ApiController]
  public class PriceController : ControllerBase
  {
    private readonly IMediator _mediator;
    public PriceController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("addPriceIn")]
    public async Task<ActionResult<ItemDTO>> addPriceIn([FromBody] PriceInDTO priceInDTO)
    {
      var command = new AddPriceInCommand(priceInDTO);
      var priceIn = await _mediator.Send(command);
      return Ok(priceInDTO);
    }

    [HttpPost("addPriceOut")]
    public async Task<ActionResult<ItemDTO>> addPriceOut([FromBody] PriceOutDTO priceOutDTO)
    {
      var command = new AddPriceOutCommand(priceOutDTO);
      var priceIn = await _mediator.Send(command);
      return Ok(priceOutDTO);
    }

    [HttpGet("getItemPriceIn/{itemID}")]
    public async Task<ActionResult<PriceInDTO>> getItemPriceIn(int itemID)
    {
      var query = new GetItemPriceInQuery(itemID);
      var price = await _mediator.Send(query);
      return Ok(price);
    }
    
    [HttpGet("getItemPriceOut/{itemID}")]
    public async Task<ActionResult<PriceOutDTO>> getItemPriceOut(int itemID)
    {
      var query = new GetItemPriceOutQuery(itemID);
      var price = await _mediator.Send(query);
      return Ok(price);
    }
  }