
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetClientQueryHandeler : IRequestHandler<GetClientQuery, ClientDTO>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetClientQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<ClientDTO> Handle(GetClientQuery request, CancellationToken cancellationToken)
    {

        Client? client = await _dbContext.Clients.Where(x => x.Id == request.clientId).FirstOrDefaultAsync();
        return _mapper.Map<ClientDTO>(client);
    }
}