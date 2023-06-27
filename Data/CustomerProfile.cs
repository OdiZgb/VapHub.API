using AutoMapper;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Trader, TraderDTO>();
        CreateMap<List<Trader>, List<TraderDTO>>();
        CreateMap<TraderDTO, Trader>();
        CreateMap<List<TraderDTO>, List<Trader>>();
    }
}