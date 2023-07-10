public class ExpenseItem
{
    [System.ComponentModel.DataAnnotations.Key]
    public int Id { set; get; }
    public string? Name { get; set; }
    public double Cost { get; set; }
    public int ExpenseCategoryId { get; set; }
    public int EmployeeId { get; set; }
    public ExpenseCategory? ExpenseCategory { get; set; }
    public Employee? Employee { get; set; }
    public DateTime dateTime { set; get; } = DateTime.Now;
    public string? Notes { set; get; } // The added field
}