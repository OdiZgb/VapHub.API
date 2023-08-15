using MediatR;


  public class LoginCommand : IRequest<UserDTO>
  {
    public UserDTO _userDTO;
    public LoginCommand(UserDTO userDTO)
    {
      _userDTO = userDTO;
    }
  }
