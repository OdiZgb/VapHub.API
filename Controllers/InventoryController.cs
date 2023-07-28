using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("inventory")]
  [ApiController]
  public class InventoryController : ControllerBase
  {
    private readonly IMediator _mediator;
    public InventoryController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("addToInventory")]
    public async Task<ActionResult<List<InventoryDTO>>> addToInventory([FromBody] List<InventoryDTO> inventoryDTOs)
    {
      var command = new AddToInventoryCommand(inventoryDTOs);
      var InventoryDTOs = await _mediator.Send(command);
      return Ok(InventoryDTOs);
    }

    [HttpGet("getInventory/{itemID}")]
    public async Task<ActionResult<InventoryDTO>> getInventory(int itemID)
    {
      var query = new GetInventoryQuery(itemID);
      var inventoryDTO = await _mediator.Send(query);
      return Ok(inventoryDTO);
    }
    
  [HttpGet("getAllInventory")]
  public async Task<ActionResult<IEnumerable<InventoryDTO>>> getAllInventory()
  {
    var query = new GetAllInventoryQuery();
    var AllInventory = await _mediator.Send(query);
    return Ok(AllInventory);
  }

  [HttpGet("getCurrentQuantites")]
  public async Task<ActionResult<IEnumerable<ItemQuantityDTO>>> getCurrentQuantites()
  {
    var query = new GetCurrentQuantitesQuery();
    var CurrentQuantites = await _mediator.Send(query);
    return Ok(CurrentQuantites);
  }
  }