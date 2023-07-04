
using AutoMapper;
using Data;
using MediatR;
public class AddExpenseCategoryCommandHandeler : IRequestHandler<AddExpenseCategoryCommand, ExpenseCategoryDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddExpenseCategoryCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ExpenseCategoryDTO> Handle(AddExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var expenseCategory = _mapper.Map<ExpenseCategory>(request._expenseCategoryDTO);

        var expenseCategoryDB = _dbContext.ExpenseCategories.Add(expenseCategory);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<ExpenseCategoryDTO>(expenseCategory);
    }
}
