namespace Models{
  public class Item {
    [System.ComponentModel.DataAnnotations.Key]
    public int Id{set;get;}
    public string Name{get;set;}
    public string? Barcode { get; set; }
    public int PriceInId {get;set;}
    public int PriceOutId {get;set;}
    public int CategoryId {get;set;}
    public int MarkaId {get;set;}
    public PriceIn? PriceIn {get;set;}
    public PriceOut? PriceOut {get;set;}
    public Category? Category {get;set;}
    public Marka? Marka {get;set;}
    public ICollection<ItemImage>? itemImages{set;get;}

  }
}