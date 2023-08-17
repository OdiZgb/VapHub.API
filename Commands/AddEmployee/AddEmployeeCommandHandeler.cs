
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
        var existingUser = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == employee.UserId);

        if (existingUser != null)
        {
            employee.User = existingUser;
            var employeeDB = _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            var userDB = _dbContext.Users.Add(employee.User);
            await _dbContext.SaveChangesAsync();

            var employeeDB = _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        return _mapper.Map<EmployeeDTO>(employee);
    }
}
