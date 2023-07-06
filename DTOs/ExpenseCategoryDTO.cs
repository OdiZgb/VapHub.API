public class ExpenseCategoryDTO{
  public int Id{set;get;}
  public string Name{set;get;}
  public string? Description{set;get;}
  public List<ExpenseItemDTO>? ExpenseItems;
}