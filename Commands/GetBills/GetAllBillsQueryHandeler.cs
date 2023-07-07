
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllBillQueryHandeler : IRequestHandler<GetAllBillsQuery, IEnumerable<BillDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllBillQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BillDTO>> Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
    {
        List<Bill> bills = await _dbContext.Bills.Include(x=>x.ClientDebt).ToListAsync();
            var a =_mapper.Map<List<BillDTO>>(bills);
        return a;
    }
}