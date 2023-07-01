
using AutoMapper;
using Data;
using MediatR;
public class AddClientCommandHandeler : IRequestHandler<AddClientCommand, ClientDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddClientCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ClientDTO> Handle(AddClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request._client);

        var clientDB = _dbContext.Clients.Add(client);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<ClientDTO>(client);
    }
}
