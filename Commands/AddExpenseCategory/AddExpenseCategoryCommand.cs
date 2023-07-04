using MediatR;

  public class AddExpenseCategoryCommand : IRequest<ExpenseCategoryDTO>
  {
    public ExpenseCategoryDTO _expenseCategoryDTO;
    public AddExpenseCategoryCommand(ExpenseCategoryDTO expenseCategoryDTO)
    {
      _expenseCategoryDTO = expenseCategoryDTO;
    }
  }