public class ClientDebt
{
    public int Id { set; get; }
    public int? BillId { set; get; }
    public int ClientId { set; get; }
    public int EmployeeId { set; get; }
    public double DebtValue { set; get; }
    public double DebtPayed { set; get; }
    public bool DebtFree { set; get; }
    public DateTime DebtDate{set;get;}
    public DateTime? DebtFreeDate {set;get;}
    public Employee Employee;
    public Client Client;
    public Bill? Bill;
}