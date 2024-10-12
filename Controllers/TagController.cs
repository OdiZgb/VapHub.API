using MediatR;
using Microsoft.AspNetCore.Mvc;

  [Route("tag")]
  [ApiController]
  public class TagController : ControllerBase
  {
    private readonly IMediator _mediator;
    public TagController(IMediator mediator)
    {
      _mediator = mediator;
    }

    [HttpPost("addTag")]
    public async Task<ActionResult<TagDTO>> addTag([FromBody] TagDTO tagDTO)
    {
      var command = new AddTagCommand(tagDTO);
      var tag = await _mediator.Send(command);
      return Ok(tag);
      
    }
 
    [HttpGet("getTag/{tagId}")]
    public async Task<ActionResult<TagDTO>> getTag(int tagId)
    {
      var query = new GetTagQuery(tagId);
      var tag = await _mediator.Send(query);
      return Ok(tag);
    }
    
    [HttpGet("getAllTags")]
    public async Task<ActionResult<IEnumerable<TagDTO>>> getAllTags()
    {
      var query = new GetAllTagsQuery();
      var Tags = await _mediator.Send(query);
      return Ok(Tags);
    }

    [HttpGet("getAllTagsByItemId/{ItemId}")]
    public async Task<ActionResult<IEnumerable<TagItemDTO>>> getAllTagsByItemId(int ItemId)
    {
        var query = new GetAllTagsByItemIdQuery(ItemId);
        var allTagsForItem = await _mediator.Send(query);
        return Ok(allTagsForItem);
    }
  }