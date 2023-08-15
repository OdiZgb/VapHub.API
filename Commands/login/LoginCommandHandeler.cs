
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Data;
using MediatR;
using Microsoft.IdentityModel.Tokens;

public class LoginCommandHandeler : IRequestHandler<LoginCommand, UserDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public LoginCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<UserDTO> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
 
        var user = _dbContext.Users.FirstOrDefault(x=>x.Name==request._userDTO.Name || x.Email==request._userDTO.Email);
        if(user==null || user.Password!=request._userDTO.Password){
            return null;
        }
        
   var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes("YourSecretKeyHere"); // Same key as in the configuration
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Id.ToString())
            // You can include other user's claims here
        }),
        Expires = DateTime.UtcNow.AddHours(111), // Token expiration time
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    var tokenString = tokenHandler.WriteToken(token);

    var userDTO = new UserDTO(){
        Email = user.Email,
        Name = user.Name,
        Id = user.Id,
        SecurityLevel = user.SecurityLevel,
        UserType = user.UserType,
        token = tokenString
    };
    return userDTO;
}

 
}
