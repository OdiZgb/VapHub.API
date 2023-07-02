
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetSalaryQueryHandeler : IRequestHandler<GetSalaryQuery, SalaryDTO>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetSalaryQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<SalaryDTO> Handle(GetSalaryQuery request, CancellationToken cancellationToken)
    {

        Salary? salary = await _dbContext.Salarys.Where(x => x.EmployeeId == request.employeeId).FirstOrDefaultAsync();
        return _mapper.Map<SalaryDTO>(salary);
    }
}