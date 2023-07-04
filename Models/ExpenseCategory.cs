public class ExpenseCategory{
  public int Id{set;get;}
  public string Name{set;get;}
  public string? Description{set;get;}
  public ICollection<ExpenseItem>? expenseItems {set;get;}
  
}