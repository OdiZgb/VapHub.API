using Commands.deleteItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;



[Route("item")]
[ApiController]
public class ItemController : ControllerBase
{
  private readonly IMediator _mediator;
  public ItemController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("addItem")]
  public async Task<ActionResult<ItemDTO>> addItem([FromBody] ItemDTO itemDTO)
  {
    var command = new AddItemCommand(itemDTO);
    var item = await _mediator.Send(command);
    return Ok(item);
  }
  
  [HttpPost("addItemImage")]
  public async Task<ActionResult<ItemImageDTO>> addItemImage([FromForm] ItemImageDTO itemImageDTO)
  {
    var command = new AddItemImageCommand(itemImageDTO);
    var itemImage = await _mediator.Send(command);
    return Ok(itemImage);
  }

  [HttpPut("editItem")]
  public async Task<ActionResult<ItemDTO>> editItem([FromBody] ItemDTO itemDTO)
  {
    var command = new EditItemCommand(itemDTO);
    var item = await _mediator.Send(command);
    return Ok(item);
  }
  
  [HttpDelete("deleteItem/{id}")]
  public async Task<ActionResult<bool>> deleteItem(int id)
  {
    var command = new DeleteItemCommand(id);
    var item = await _mediator.Send(command);
    return Ok("deleted.");
  }
  [HttpGet("getItem/{id}")]
  public async Task<ActionResult<ItemDTO>> getItem(int id)
  {
   var query = new GetItemQuery(id);
    var items = await _mediator.Send(query);
    return Ok(items);
  }

  [HttpGet("getAllItems")]
  public async Task<ActionResult<IEnumerable<ItemDTO>>> getAllItems()
  {
    var query = new GetAllItemsQuery();
    var items = await _mediator.Send(query);
    return Ok(items);
  }
}