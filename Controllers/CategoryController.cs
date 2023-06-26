using Commands.deleteItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;



[Route("category")]
[ApiController]
public class CategoryController : ControllerBase
{
  private readonly IMediator _mediator;
  public CategoryController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpPost("addCategory")]
  public async Task<ActionResult<ItemDTO>> addCategory([FromBody] CategoryDTO categoryDTO)
  {
    var command = new AddCategoryCommand(categoryDTO);
    var category = await _mediator.Send(command);
    return Ok(category);
  }
  [HttpDelete("deleteCategory/{id}")]
  public async Task<ActionResult<bool>> deleteCategory(int id)
  {
    var command = new DeleteCategoryCommand(id);
    var category = await _mediator.Send(command);
    return Ok("deleted.");
  }
  [HttpGet("getAllGategorie")]
  public async Task<ActionResult<IEnumerable<ItemDTO>>> getAllItems()
  {
    var query = new GetAllGategoriesQuery();
    var categories = await _mediator.Send(query);
    return Ok(categories);
  }
}