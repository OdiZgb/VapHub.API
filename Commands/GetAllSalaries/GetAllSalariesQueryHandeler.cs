
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllSalarysQueryHandeler : IRequestHandler<GetAllSalarysQuery, IEnumerable<SalaryDTO>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetAllSalarysQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<SalaryDTO>> Handle(GetAllSalarysQuery request, CancellationToken cancellationToken)
    {

        List<Salary> salarys = await _dbContext.Salarys.ToListAsync();
        return _mapper.Map<List<SalaryDTO>>(salarys);
    }
}