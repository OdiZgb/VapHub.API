public class BillDTO{
    public int Id { set; get; }
    public int ClientId { set; get; }
    public int EmployeeId { set; get; }
    public int ClientDebtId { set; get; }
    public double RequierdPrice {set;get;}
    public double PaiedPrice {set;get;}
    public double ExchangeRepaied {set;get;}
    public bool completed = false;
    public DateTime Time {set;get;}
    public EmployeeDTO? Employee;
    public ClientDTO? Client;
    public ClientDebtDTO? ClientDebt{set;get;}
    public ICollection<ItemDTO> Items{set;get;}
}