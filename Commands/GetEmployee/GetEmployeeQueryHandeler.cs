
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetEmployeeQueryHandeler : IRequestHandler<GetEmployeeQuery, EmployeeDTO>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetEmployeeQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<EmployeeDTO> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
    {

        Employee? employee = await _dbContext.Employees.Where(x => x.Id == request.employeeId).FirstOrDefaultAsync();
        return _mapper.Map<EmployeeDTO>(employee);
    }
}