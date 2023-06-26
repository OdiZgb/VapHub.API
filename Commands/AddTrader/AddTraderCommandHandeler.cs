
using AutoMapper;
using Data;
using MediatR;
public class AddTraderCommandHandeler : IRequestHandler<AddTraderCommand, TraderDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddTraderCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TraderDTO> Handle(AddTraderCommand request, CancellationToken cancellationToken)
    {
        var trader = _mapper.Map<Trader>(request._trader);

        var traderDB = _dbContext.Traders.Add(trader);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<TraderDTO>(trader);
    }
}
