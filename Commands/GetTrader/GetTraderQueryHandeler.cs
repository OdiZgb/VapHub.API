
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetTraderQueryHandeler : IRequestHandler<GetTraderQuery, TraderDTO>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetTraderQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<TraderDTO> Handle(GetTraderQuery request, CancellationToken cancellationToken)
    {

        Trader? trader = await _dbContext.Traders.Where(x => x.Id == request.traderId).FirstOrDefaultAsync();
        return _mapper.Map<TraderDTO>(trader);
    }
}