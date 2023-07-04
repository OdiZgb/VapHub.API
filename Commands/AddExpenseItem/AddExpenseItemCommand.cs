using MediatR;


  public class AddExpenseItemCommand : IRequest<ExpenseItemDTO>
  {
    public ExpenseItemDTO _expenseItem;
    public AddExpenseItemCommand(ExpenseItemDTO expenseItem)
    {
      _expenseItem = expenseItem;
    }
  }
