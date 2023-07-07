public class Bill{
    public int Id { set; get; }
    public int? ClientId { set; get; }
    public int? EmployeeId { set; get; }
    public int? ClientDebtId { set; get; }
    public double RequierdPrice {set;get;}
    public double PaiedPrice {set;get;}
    public double ExchangeRepaied {set;get;}
    public bool completed = false;
    public DateTime Time {set;get;}
    public Employee? Employee;
    public Client? Client;
    public ClientDebt? ClientDebt{set;get;}
    public ICollection<Item> Items{set;get;}
}