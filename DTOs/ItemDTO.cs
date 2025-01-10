
public class ItemDTO{
    public int Id{set;get;}
    public string? Name{set;get;}
    public string? Barcode{set;get;}
    public List<ItemImageDTO>? ItemsImageDTOs{set;get;}
    public PriceInDTO? PriceInDTO {get;set;}
    public PriceOutDTO? PriceOutDTO {get;set;}
    public MarkaDTO? MarkaDTO {get;set;}
    public CategoryDTO? CategoryDTO {get;set;}

    public List<TagItemDTO>? TagItemDTOs{set;get;}
    public List<TagDTO>? TagsDTO{set;get;}

    public static implicit operator ItemDTO(Item v)
    {
        throw new NotImplementedException();
    }
}