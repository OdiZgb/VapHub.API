
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllTradersQueryHandeler : IRequestHandler<GetAllTradersQuery, IEnumerable<TraderDTO>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetAllTradersQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<TraderDTO>> Handle(GetAllTradersQuery request, CancellationToken cancellationToken)
    {

        List<Trader> traders = await _dbContext.Traders.ToListAsync();
        return _mapper.Map<List<TraderDTO>>(traders);
    }
}