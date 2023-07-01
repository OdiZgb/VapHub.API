using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Trader, TraderDTO>();
        CreateMap<TraderDTO, Trader>();
        CreateMap<EmployeeDTO, Employee>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Client, ClientDTO>();
        CreateMap<ClientDTO, Client>();
    }
}