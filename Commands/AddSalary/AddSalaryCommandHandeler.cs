
using AutoMapper;
using Data;
using MediatR;
public class AddSalaryCommandHandeler : IRequestHandler<AddSalaryCommand, SalaryDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddSalaryCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<SalaryDTO> Handle(AddSalaryCommand request, CancellationToken cancellationToken)
    {
        var salary = _mapper.Map<Salary>(request._salary);

        var salaryDB = _dbContext.Salarys.Add(salary);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<SalaryDTO>(salary);
    }
}
