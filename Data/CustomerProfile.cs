using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Trader, TraderDTO>();
        CreateMap<TraderDTO, Trader>();
    }
}