using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile(){
        CreateMap<Bill, BillDTO>().ReverseMap();
        CreateMap<ClientDebt, ClientDebtDTO>().ReverseMap();
        CreateMap<CategoryProperty, CategoryPropertyDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Client, ClientDTO>().ReverseMap();
        CreateMap<EmployeeDTO, Employee>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
        .ReverseMap();
        CreateMap<Inventory, InventoryDTO>().ReverseMap();
        CreateMap<Item, ItemDTO>().ReverseMap();
        CreateMap<ItemImage, ItemImageDTO>().ReverseMap();
        CreateMap<Salary, SalaryDTO>().ReverseMap();
        CreateMap<Marka, MarkaDTO>().ReverseMap();
        CreateMap<PriceIn, PriceInDTO>().ReverseMap();
        CreateMap<Trader, TraderDTO>().ReverseMap();
        CreateMap<ExpenseCategory, ExpenseCategoryDTO>().ReverseMap();
        CreateMap<ExpenseItem, ExpenseItemDTO>().ReverseMap();
        CreateMap<User, UserDTO>().ReverseMap();

        // For complex nested mapping
        CreateMap<Inventory, InventoryDTO>()
            .ForMember(dest => dest.ItemDTO, opt => opt.MapFrom(src => src.Item))
            .ForPath(dest => dest.ItemDTO.CategoryDTO, opt => opt.MapFrom(src => src.Item.Category))
            .ForPath(dest => dest.ItemDTO.MarkaDTO, opt => opt.MapFrom(src => src.Item.Marka))
            .ForPath(dest => dest.PriceInDTO, opt => opt.MapFrom(src => src.PriceIn))
            .ForPath(dest => dest.TraderDTO, opt => opt.MapFrom(src => src.Trader))
            .ForPath(dest => dest.EmployeeDTO, opt => opt.MapFrom(src => src.Employee));
    }
}
