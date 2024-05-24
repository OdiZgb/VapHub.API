public class HistoryOfCashBill
{
    public int Id { set; get; }
    public string? ItemName { get; set; }
    public string? ItemId { get; set; }
    public string? ItemBarcode { get; set; }
    public double? ItemCostIn { get; set; }
    public double? ItemCostOut { get; set; }
    public string? EmployeeName { get; set; }
    public int? EmployeeId { get; set; }
    public string? ClientName { get; set; }
    public int? ClientId { get; set; }
    public int? InventoryName { get; set; }
    public int? InventoryId { get; set; }
    public string? barcode{set;get;}
    public int? billId { get; set; }
    public string? TraderName{set;get;}
    public int? TraderId { get; set; }
    public double? RequierdPrice {set;get;}
    public double? ClientCashPayed {set;get;}
    public double? ClientRecived {set;get;}
}