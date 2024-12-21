using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    public async Task<ActionResult<List<InventoryDTO>>> AddToInventory([FromBody] List<InventoryDTO> inventoryDTOs)
    {
        var command = new AddToInventoryCommand(inventoryDTOs);
        var inventoryDTOsResult = await _mediator.Send(command);
        return Ok(inventoryDTOsResult);
    }

    [HttpGet("getInventory/{itemID}")]
    public async Task<ActionResult<InventoryDTO>> GetInventory(int itemID)
    {
        var query = new GetInventoryQuery(itemID);
        var inventoryDTO = await _mediator.Send(query);
        return Ok(inventoryDTO);
    }

    [HttpGet("getAllInventory")]
    public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetAllInventory()
    {
        var query = new GetAllInventoryQuery();
        var allInventory = await _mediator.Send(query);
        return Ok(allInventory);
    }

    [HttpGet("getAllInventoryPagination")]
    public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetAllInventory([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        // Validate the page size to prevent potential performance issues
        if (pageSize <= 0 || pageNumber <= 0)
        {
            return BadRequest("Page number and page size must be greater than zero.");
        }

        var query = new GetAllInventoryPaginationQuery(pageNumber, pageSize);
        var allInventory = await _mediator.Send(query);

        if (allInventory == null || !allInventory.Any())
        {
            return NotFound("No inventory items found for the given parameters.");
        }

        return Ok(allInventory);
    }


    [HttpGet("getAllInventoryByBarcode/{barcode}")]
    public async Task<ActionResult<IEnumerable<InventoryDTO>>> GetAllInventoryByBarcode(string barcode)
    {
        var query = new GetAllInventoryQueryByBarcodeQuery(barcode);
        var allInventory = await _mediator.Send(query);
        return Ok(allInventory);
    }

    [HttpGet("getInventoryImage/{barcode}")]
    public async Task<ActionResult<string>> GetInventoryImage(string barcode)
    {
        var query = new getInventoryImageQuery(barcode);
        var image = await _mediator.Send(query);
        return Ok(image);
    }

    [HttpGet("getCurrentQuantites")]
    public async Task<ActionResult<IEnumerable<ItemQuantityDTO>>> GetCurrentQuantites()
    {
        var query = new GetCurrentQuantitesQuery();
        var currentQuantites = await _mediator.Send(query);
        return Ok(currentQuantites);
    }

    [HttpGet("GetCash")]
    public async Task<ActionResult<IEnumerable<HistoryOfCashBill>>> GetCash()
    {
        var query = new GetCashQuery();
        var cash = await _mediator.Send(query);
        return Ok(cash);
    }

    [HttpGet("GetDeletedCash")]
    public async Task<ActionResult<IEnumerable<HistoryOfCashBill>>> GetDeletedCash()
    {
        var query = new GetDeletedCashQuery();
        var cash = await _mediator.Send(query);
        return Ok(cash);
    }

    [HttpPost("addShipmentImage")]
    public async Task<ActionResult<ItemImageDTO>> AddShipmentImage([FromForm] ShipmentImageDTO shipmentImageDTO)
    {
        var command = new AddShipmentImageCommand(shipmentImageDTO);
        var shipmentImage = await _mediator.Send(command);
        return Ok(shipmentImage);
    }

    [HttpPut("editInventoryQuantity/{id}")]
    public async Task<ActionResult<InventoryDTO>> EditInventoryQuantity(int id, [FromBody] UpdateInventoryQuantityDTO quantityDTO)
    {
        var command = new EditInventoryQuantityCommand(id, quantityDTO);
        var updatedInventory = await _mediator.Send(command);
        return Ok(updatedInventory);
    }

}
