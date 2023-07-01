using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        
        CreateMap<CategoryProperty, CategoryPropertyDTO>();
        CreateMap<CategoryPropertyDTO, CategoryProperty>();

        CreateMap<Category, CategoryDTO>();
        CreateMap<CategoryDTO, Category>();

        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();

        CreateMap<EmployeeDTO, Employee>();
        CreateMap<Employee, EmployeeDTO>();

        CreateMap<Inventory, InventoryDTO>();
        CreateMap<InventoryDTO, Inventory>();

        CreateMap<Item, ItemDTO>();
        CreateMap<ItemDTO, Item>();

        CreateMap<ItemImage, ItemImageDTO>();
        CreateMap<ItemImageDTO, ItemImage>();

        CreateMap<Marka, MarkaDTO>();
        CreateMap<MarkaDTO, Marka>();
 
        CreateMap<PriceIn, PriceInDTO>();
        CreateMap<PriceInDTO, PriceIn>();

        CreateMap<Trader, TraderDTO>();
        CreateMap<TraderDTO, Trader>();

    }
}