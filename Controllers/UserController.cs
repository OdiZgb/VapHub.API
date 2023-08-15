using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserDTO>> login([FromBody] UserDTO userDTO)
    {
        var command = new LoginCommand(userDTO);
        var user = await _mediator.Send(command);
        
        if(user==null){
            return Unauthorized("make sure you have entered the data right");
        }

        return Ok(user);
    }
 
}