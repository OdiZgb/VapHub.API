

public class InventoryDTO{
  public int Id{set;get;}
  public int ItemId{set;get;}
  public int? PatchId{set;get;}
  public int? NumberOfUnits{set;get;}
  public int? PriceInId{set;get;}
  public int? TraderId{set;get;}
  public TraderDTO? Trader{set;get;}
  public ItemDTO? ItemDTO{set;get;}
  public PriceInDTO? PriceInDTO{set;get;}
  public DateTime ArrivalDate{set;get;} = DateTime.Now;
  public DateTime ManufacturingDate{set;get;}
  public DateTime ExpirationDate{set;get;}
}