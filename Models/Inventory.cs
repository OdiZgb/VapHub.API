
public class Inventory{
  public int Id{set;get;}
  public int ItemId{set;get;}
  public int? NumberOfUnits{set;get;}
  public int? PatchId{set;get;}
  public int? PriceInId{set;get;}
  public Item? Item{set;get;}
  public int? TraderId {set;get;}
  public int? EmployeeId {set;get;}
  public PriceIn PriceIn{set;get;}
  public DateTime ArrivalDate{set;get;} = DateTime.Now;
  public DateTime ManufacturingDate{set;get;}
  public DateTime ExpirationDate{set;get;}
  public Trader? Trader{set;get;}
  public Employee? Employee{set;get;}
}