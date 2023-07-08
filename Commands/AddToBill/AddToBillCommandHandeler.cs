
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class AddToBillCommandHandeler : IRequestHandler<AddToBillCommand, BillDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;

    private readonly IMediator _mediator;
    public AddToBillCommandHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<BillDTO> Handle(AddToBillCommand request, CancellationToken cancellationToken)
    {

        Bill bill = new Bill();

        List<Item> items = new List<Item>();
        double requierdPrice = 0;
        double paiedPrice = request._billDTO.PaiedPrice;
        Client client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == request._billDTO.ClientId);
        foreach (var item in request._billDTO.Items)
        {
            var itemDB = await _dbContext.Items.Include(x => x.Category).Include(x => x.Marka).Include(x => x.PriceIn).Include(x => x.PriceOut).FirstOrDefaultAsync(x => x.Id == item.Id);
            if (itemDB != null && itemDB.PriceOut != null)
            {
                requierdPrice = requierdPrice + itemDB.PriceOut.Price;
                items.Add(itemDB);
            }
        }

        bill.Client = client;
        bill.Employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request._billDTO.EmployeeId);
        bill.RequierdPrice = requierdPrice;
        bill.ExchangeRepaied = request._billDTO.ExchangeRepaied;
        bill.Items = items;
        bill.PaiedPrice = request._billDTO.PaiedPrice;
        bill.Time = DateTime.Now;
        bill.completed = true;

 
        var Bill = await _dbContext.Bills.AddAsync(bill);
        await _dbContext.SaveChangesAsync(cancellationToken);

        if (requierdPrice != paiedPrice)
        {
            if (requierdPrice > paiedPrice)
            {
                Bill.Entity.completed = false;
                var clientDebt = new ClientDebt(){
                    BillId = Bill.Entity.Id,
                    Client = Bill.Entity.Client,
                    ClientId = Bill.Entity.Client.Id,
                    DebtDate = DateTime.Now,
                    DebtFree = false,
                    DebtFreeDate = null,
                    DebtPayed = 0 ,
                    DebtValue = requierdPrice - paiedPrice,
                    Employee = Bill.Entity.Employee,
                    EmployeeId = Bill.Entity.Employee.Id
                };
                
                var ClientDebt = await _dbContext.ClientDebts.AddAsync(clientDebt);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Bill.Entity.ClientDebt = ClientDebt.Entity;
                await _dbContext.SaveChangesAsync(cancellationToken);
             }
             if(paiedPrice - request._billDTO.ExchangeRepaied > requierdPrice){
                Bill.Entity.completed = false;
                var clientDebt = new ClientDebt(){
                    BillId = Bill.Entity.Id,
                    Client = Bill.Entity?.Client,
                    ClientId = Bill.Entity.Client.Id,
                    DebtDate = DateTime.Now,
                    DebtFree = false,
                    DebtFreeDate = null,
                    DebtPayed = 0 ,
                    DebtValue = (Bill.Entity.PaiedPrice - Bill.Entity.ExchangeRepaied - Bill.Entity.RequierdPrice)* -1,
                    Employee = Bill.Entity.Employee,
                    EmployeeId = Bill.Entity.Employee.Id
                };
                
                var ClientDebt = await _dbContext.ClientDebts.AddAsync(clientDebt);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Bill.Entity.ClientDebt = ClientDebt.Entity;
                await _dbContext.SaveChangesAsync(cancellationToken);             }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);


        return _mapper.Map<BillDTO>(bill);
    }
}
