
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllClientsQueryHandeler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetAllClientsQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {

        List<Client> clients = await _dbContext.Clients.ToListAsync();
        return _mapper.Map<List<ClientDTO>>(clients);
    }
}