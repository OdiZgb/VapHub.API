
using AutoMapper;
using Data;
using MediatR;
public class AddEmployeeCommandHandeler : IRequestHandler<AddEmployeeCommand, EmployeeDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddEmployeeCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<EmployeeDTO> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(request._employee);

        var employeeDB = _dbContext.Employees.Add(employee);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<EmployeeDTO>(employee);
    }
}
