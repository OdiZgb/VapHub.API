public class ExpenseItemDTO{
    public int Id { set; get; }
    public string? Name { get; set; }
    public double Cost { get; set; }
    public int ExpenseCategoryId { get; set; }
    public int EmployeeId { get; set; }
    public ExpenseCategoryDTO? ExpenseCategory { get; set; }
    public EmployeeDTO? Employee { get; set; }
    public DateTime dateTime { set; get; } = DateTime.Now;
}