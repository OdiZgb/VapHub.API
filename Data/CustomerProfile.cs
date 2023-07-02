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

        CreateMap<Inventory, InventoryDTO>()
            .ForMember(dest => dest.ItemDTO, opt => opt.MapFrom(src => src.Item))
            .ForPath(dest => dest.ItemDTO.CategoryDTO, opt => opt.MapFrom(src => src.Item.Category))
            .ForPath(dest => dest.ItemDTO.MarkaDTO, opt => opt.MapFrom(src => src.Item.Marka))
            .ForPath(dest => dest.PriceInDTO, opt => opt.MapFrom(src => src.PriceIn))
            .ForPath(dest => dest.TraderDTO, opt => opt.MapFrom(src => src.Trader))
            .ForPath(dest => dest.EmployeeDTO, opt => opt.MapFrom(src => src.Employee));

        CreateMap<InventoryDTO, Inventory>();

        CreateMap<Item, ItemDTO>();
        CreateMap<ItemDTO, Item>();

        CreateMap<ItemImage, ItemImageDTO>();
        CreateMap<ItemImageDTO, ItemImage>();

        CreateMap<Salary, SalaryDTO>();
        CreateMap<SalaryDTO, Salary>();

        CreateMap<Marka, MarkaDTO>();
        CreateMap<MarkaDTO, Marka>();
 
        CreateMap<PriceIn, PriceInDTO>();
        CreateMap<PriceInDTO, PriceIn>();

        CreateMap<Trader, TraderDTO>();
        CreateMap<TraderDTO, Trader>();

    }
}