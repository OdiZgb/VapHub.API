using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class AddToBillCommandHandler : IRequestHandler<AddToBillCommand, BillDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    public AddToBillCommandHandler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<BillDTO> Handle(AddToBillCommand request, CancellationToken cancellationToken)
    {
        Bill bill = new Bill();
        List<Item> items = new List<Item>();
        double requiredPrice = 0;
        double paidPrice = request._billDTO.PaiedPrice;

        // Fetch the client and check if it is null
        Client client = await _dbContext.Clients.FirstOrDefaultAsync(x => x.Id == request._billDTO.ClientId);
        if (client == null)
        {
            Console.WriteLine($"Client not found: ClientId={request._billDTO.ClientId}");
            throw new Exception($"Client with ID {request._billDTO.ClientId} not found.");
        }

        // Process items and check each item
        foreach (var item in request._billDTO.Items)
        {
            var itemDB = await _dbContext.Items
                .Include(x => x.Category)
                .Include(x => x.Marka)
                .Include(x => x.PriceIn)
                .Include(x => x.PriceOut)
                .FirstOrDefaultAsync(x => x.Id == item.Id);

            if (itemDB != null && itemDB.PriceOut != null)
            {
                requiredPrice += itemDB.PriceOut.Price;
                items.Add(itemDB);
            }
            else
            {
                Console.WriteLine($"Item not found or item price not set: ItemId={item.Id}");
                throw new Exception($"Item with ID {item.Id} not found or item price not set.");
            }
        }

        // Fetch the employee and check if it is null
        var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request._billDTO.EmployeeId);
        if (employee == null)
        {
            Console.WriteLine($"Employee not found: EmployeeId={request._billDTO.EmployeeId}");
            throw new Exception($"Employee with ID {request._billDTO.EmployeeId} not found.");
        }

        bill.Client = client;
        bill.Employee = employee;
        bill.RequierdPrice = requiredPrice;
        bill.ExchangeRepaied = request._billDTO.ExchangeRepaied;
        bill.Items = items;
        bill.PaiedPrice = paidPrice;
        bill.Time = DateTime.Now;
        bill.completed = true;

        var Bill = await _dbContext.Bills.AddAsync(bill);
        await _dbContext.SaveChangesAsync(cancellationToken);

        // Additional logic for handling client debts
        if (requiredPrice != paidPrice)
        {
            if (requiredPrice > paidPrice)
            {
                Bill.Entity.completed = false;
                var clientDebt = new ClientDebt
                {
                    BillId = Bill.Entity.Id,
                    Client = Bill.Entity.Client,
                    ClientId = Bill.Entity.Client.Id,
                    DebtDate = DateTime.Now,
                    DebtFree = false,
                    DebtFreeDate = null,
                    DebtPayed = 0,
                    DebtValue = requiredPrice - paidPrice,
                    Employee = Bill.Entity.Employee,
                    EmployeeId = Bill.Entity.Employee.Id
                };

                var ClientDebt = await _dbContext.ClientDebts.AddAsync(clientDebt);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Bill.Entity.ClientDebt = ClientDebt.Entity;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
            if (paidPrice - request._billDTO.ExchangeRepaied > requiredPrice)
            {
                Bill.Entity.completed = false;
                var clientDebt = new ClientDebt
                {
                    BillId = Bill.Entity.Id,
                    Client = Bill.Entity?.Client,
                    ClientId = Bill.Entity.Client.Id,
                    DebtDate = DateTime.Now,
                    DebtFree = false,
                    DebtFreeDate = null,
                    DebtPayed = 0,
                    DebtValue = (Bill.Entity.PaiedPrice - Bill.Entity.ExchangeRepaied - Bill.Entity.RequierdPrice) * -1,
                    Employee = Bill.Entity.Employee,
                    EmployeeId = Bill.Entity.Employee.Id
                };

                var ClientDebt = await _dbContext.ClientDebts.AddAsync(clientDebt);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Bill.Entity.ClientDebt = ClientDebt.Entity;
                await _dbContext.SaveChangesAsync(cancellationToken);
            }
        }

        await _dbContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BillDTO>(bill);
    }
}
