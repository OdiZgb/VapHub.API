
using System.ComponentModel.DataAnnotations.Schema;

public class ShipmentImage{
  public int? Id{set;get;}
  public string? barcode{set;get;}
  public int InventoryId{set;get;}
  public string? ImageURL{set;get;}
  public string? AlterText{set;get;}
  [NotMapped]
  public IFormFile? file{set;get;}

}