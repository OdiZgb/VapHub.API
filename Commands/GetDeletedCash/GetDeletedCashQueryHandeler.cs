
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetDeletedCashQueryHandeler : IRequestHandler<GetDeletedCashQuery, IEnumerable<HistoryOfCashBill>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetDeletedCashQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<HistoryOfCashBill>> Handle(GetDeletedCashQuery request, CancellationToken cancellationToken)
    {

        List<HistoryOfCashBill> HistoryOfCashBill = await _dbContext.HistoryOfCashBill.ToListAsync();
        List<HistoryOfCashBill> HistoryOfCashBillReady = new List<HistoryOfCashBill>();
        foreach (var item in HistoryOfCashBill)
        {
          if(item.SoftDeleted==1){
            HistoryOfCashBillReady.Add(item);
          }
        }
        return HistoryOfCashBillReady;
    }
}