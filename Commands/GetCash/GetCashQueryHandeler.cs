
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetCashQueryHandeler : IRequestHandler<GetCashQuery, IEnumerable<HistoryOfCashBill>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetCashQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<HistoryOfCashBill>> Handle(GetCashQuery request, CancellationToken cancellationToken)
    {

        List<HistoryOfCashBill> HistoryOfCashBill = await _dbContext.HistoryOfCashBill.ToListAsync();
        return HistoryOfCashBill;
    }
}