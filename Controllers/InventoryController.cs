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

  [HttpGet("getAllInventoryByBarcode/{barcode}")]
  public async Task<ActionResult<IEnumerable<InventoryDTO>>> getAllInventoryByBarcode(string barcode)
  {
    var query = new GetAllInventoryQueryByBarcodeQuery(barcode);
    var AllInventory = await _mediator.Send(query);
    return Ok(AllInventory);
  }

  [HttpGet("getInventoryImage/{barcode}")]
  public async Task<ActionResult<string>> getInventoryImage(string barcode)
  {
    var query = new getInventoryImageQuery(barcode);
    var image = await _mediator.Send(query);
    return Ok(image);
  }

  [HttpGet("getCurrentQuantites")]
  public async Task<ActionResult<IEnumerable<ItemQuantityDTO>>> getCurrentQuantites()
  {
    var query = new GetCurrentQuantitesQuery();
    var CurrentQuantites = await _mediator.Send(query);
    return Ok(CurrentQuantites);
  }
    [HttpGet("GetCash")]
  public async Task<ActionResult<IEnumerable<HistoryOfCashBill>>> GetCash()
  {
    var query = new GetCashQuery();
    var cash = await _mediator.Send(query);
    return Ok(cash);
  }
  [HttpPost("addShipmentImage")]
  public async Task<ActionResult<ItemImageDTO>> addItemImage([FromForm] ShipmentImageDTO shipmentImageDTO)
  {
    var command = new AddShipmentImageCommand(shipmentImageDTO);
    var shipmentImage = await _mediator.Send(command);
    return Ok(shipmentImage);
  }
  }