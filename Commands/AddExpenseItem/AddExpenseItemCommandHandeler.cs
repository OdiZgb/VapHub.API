
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
        var expenseCategory = await this._dbContext.ExpenseCategories.FirstOrDefaultAsync(x => x.Id == request._expenseItem.ExpenseCategoryId);
        var employee = await this._dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request._expenseItem.EmployeeId);

        if (expenseCategory == null)
        {
            throw new Exception("Expense category not found");
        }
        if (employee == null)
        {
            throw new Exception("Employee not found");
        }

        expenseItem.ExpenseCategory = expenseCategory;
        expenseItem.ExpenseCategoryId = expenseCategory.Id;
        expenseItem.Employee = employee;
        expenseItem.EmployeeId = employee.Id;
        var expenseItems =await this._dbContext.ExpenseItems.AddAsync(expenseItem);
        expenseCategory.expenseItems.Add(expenseItems.Entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ExpenseItemDTO>(expenseItem);
    }
}
