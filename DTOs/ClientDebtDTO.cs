public class ClientDebtDTO
{
    public int Id { set; get; }
    public int? BillId { set; get; }
    public string ClientId { set; get; }
    public string EmployeeId { set; get; }
    public double DebtValue { set; get; }
    public double DebtPayed { set; get; }
    public bool DebtFree { set; get; }
    public DateTime DebtDate{set;get;}
    public DateTime DebtFreeDate {set;get;}
    public DateTime PaiedTime {set;get;}
    public EmployeeDTO Employee;
    public ClientDTO Client;
    public BillDTO Bill;
}
