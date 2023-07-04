
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddExpenseItemCommandHandeler : IRequestHandler<AddExpenseItemCommand, ExpenseItemDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddExpenseItemCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<ExpenseItemDTO> Handle(AddExpenseItemCommand request, CancellationToken cancellationToken)
    {
        var expenseItem = _mapper.Map<ExpenseItem>(request._expenseItem);
        var expenseCategory = await this._dbContext.ExpenseCategories.FirstOrDefaultAsync(x=>x.Id == request._expenseItem.ExpenseCategoryId);
        var employee = await this._dbContext.Employees.FirstOrDefaultAsync(x=>x.Id == request._expenseItem.EmployeeId);
        expenseItem.ExpenseCategory =  _mapper.Map<ExpenseCategory>(expenseCategory);
        expenseItem.ExpenseCategoryId = expenseCategory.Id;
        expenseItem.Employee =  _mapper.Map<Employee>(employee);
        expenseItem.EmployeeId =  employee.Id;

        var expenseItemDB = _dbContext.ExpenseItems.Add(expenseItem);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<ExpenseItemDTO>(expenseItem);
    }
}
