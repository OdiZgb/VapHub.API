
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllClientDebtQueryHandeler : IRequestHandler<GetAllClientDebtsQuery, IEnumerable<ClientDebtDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllClientDebtQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDebtDTO>> Handle(GetAllClientDebtsQuery request, CancellationToken cancellationToken)
    {
        List<ClientDebt> clientDebts = await _dbContext.ClientDebts.Include(x=>x.Client).ToListAsync();
            var a =_mapper.Map<List<ClientDebtDTO>>(clientDebts);
        return a;
    }
}