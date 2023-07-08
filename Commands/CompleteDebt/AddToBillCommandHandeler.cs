
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class CompleteDebtCommandHandeler : IRequestHandler<CompleteDebtCommand, ClientDebtDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;

    private readonly IMediator _mediator;
    public CompleteDebtCommandHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ClientDebtDTO> Handle(CompleteDebtCommand request, CancellationToken cancellationToken)
    {
 
        var clientDebt = await _dbContext.ClientDebts.FirstOrDefaultAsync(x=>x.Id==request._id);
        clientDebt.DebtFree = true;
        clientDebt.DebtFreeDate = DateTime.Now;
        clientDebt.DebtPayed = clientDebt.DebtValue;
        await _dbContext.SaveChangesAsync(cancellationToken);
 

        return _mapper.Map<ClientDebtDTO>(clientDebt);
    }
}
