
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllEmployeesQueryHandeler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDTO>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetAllEmployeesQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {

        List<Employee> employees = await _dbContext.Employees.Include(x=>x.User).ToListAsync();
        return _mapper.Map<List<EmployeeDTO>>(employees);
    }
}