public class PriceInDTO
{
    public int Id { set; get; }
    public int ItemId { set; get; }
    public float Price { set; get; }
    public ItemDTO? Item { set; get; }
    public DateTime Date { set; get; }
    public DateTime ExpirationDate { set; get; }
}