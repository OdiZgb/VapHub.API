using MediatR;


  public class GetAllExpenseCategoriesQuery : IRequest<IEnumerable<ExpenseCategoryDTO>>
  {
    public GetAllExpenseCategoriesQuery()
    {
    }
  }
