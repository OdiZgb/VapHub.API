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

    // Process items and count occurrences
    var itemCountMap = new Dictionary<int, int>();
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

        // Track each occurrence individually if duplicates are required
        items.Add(itemDB);  // Add each occurrence of the item
    }
    else
    {
        Console.WriteLine($"Item not found or item price not set: ItemId={item.Id}");
        throw new Exception($"Item with ID {item.Id} not found or item price not set.");
    }
}
    List<HistoryOfCashBill> historyOfCashBills = new List<HistoryOfCashBill>();

    // Fetch the employee and check if it is null
    var employee = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request._billDTO.EmployeeId);
    if (employee == null)
    {
        Console.WriteLine($"Employee not found: EmployeeId={request._billDTO.EmployeeId}");
        throw new Exception($"Employee with ID {request._billDTO.EmployeeId} not found.");
    }
     
    if (employee == null)
    {
        Console.WriteLine($"Employee not found: EmployeeId={request._billDTO.EmployeeId}");
        throw new Exception($"Employee with ID {request._billDTO.EmployeeId} not found.");
    }

    bill.Client = client;
    bill.Employee = employee;
    bill.EmployeeId = request._billDTO.EmployeeId;
    bill.RequierdPrice = requiredPrice;
    bill.ExchangeRepaied = request._billDTO.ExchangeRepaied;
    bill.Items = items;
    bill.discount = request._billDTO.discount;
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

    // Optionally, log or return the item count map if needed
    foreach (var kvp in itemCountMap)
    {
        Console.WriteLine($"Item ID: {kvp.Key}, Quantity: {kvp.Value}");
    }
   List<Inventory> inventors=null;
        foreach (var item in request._billDTO.Items)
        {
            var Inventor = await _dbContext.Inventory.FirstOrDefaultAsync(x => x.Barcode == item.Barcode.Substring(item.Barcode.Length - 3));
            var Item = await _dbContext.Items.FirstOrDefaultAsync(x => x.Barcode == item.Barcode.Substring(0,3));
                
                HistoryOfCashBill historyOfCashBill = new HistoryOfCashBill();

                Client client1 = new Client();
                client = await _dbContext.Clients.FirstOrDefaultAsync(x=>x.Id==request._billDTO.ClientId);
                var employee1 = await _dbContext.Employees.FirstOrDefaultAsync(x=>x.Id==request._billDTO.EmployeeId);
                var user = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id==employee1.UserId);
                var trader = await _dbContext.Traders.FirstOrDefaultAsync(x=>x.Id==Inventor.TraderId);
                historyOfCashBill.barcode = item.Barcode;
                historyOfCashBill.ItemName = Item.Name;
                historyOfCashBill.ItemId = Item.Id;
                historyOfCashBill.ItemCostIn = Item.PriceIn.Price;
                historyOfCashBill.ItemCostOut = Item.PriceOut.Price;
                historyOfCashBill.ItemBarcode = Item.Barcode;
                historyOfCashBill.RequierdPrice = request._billDTO.RequierdPrice;
                historyOfCashBill.ClientName = client.Name;
                historyOfCashBill.billId = bill.Id;
                historyOfCashBill.EmployeeName = user.Name;
                historyOfCashBill.EmployeeId = employee1.Id;
                historyOfCashBill.ClientCashPayed = request._billDTO.PaiedPrice;
                historyOfCashBill.ClientRecived = request._billDTO.ExchangeRepaied;
                historyOfCashBill.ClientId = client.Id;
                historyOfCashBill.InventoryId = Inventor.Id;
                historyOfCashBill.TraderId = Inventor.TraderId;
                historyOfCashBill.TraderName= trader.Name;
                await _dbContext.HistoryOfCashBill.AddAsync(historyOfCashBill);
        }

                await _dbContext.SaveChangesAsync(cancellationToken);

    return _mapper.Map<BillDTO>(bill);
}

}
