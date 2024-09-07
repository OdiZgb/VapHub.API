using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class EditInventoryCommandHandler : IRequestHandler<EditInventoryCommand, InventoryDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public EditInventoryCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<InventoryDTO> Handle(EditInventoryCommand request, CancellationToken cancellationToken)
    {
        // Fetch the existing inventory record by ID
        var inventory = await _dbContext.Inventory
            .Include(x => x.Item)
            .Include(x => x.Trader)
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (inventory == null)
        {
            // Handle the case where the inventory record is not found
            // You can throw an exception or return a custom error response
            throw new KeyNotFoundException("Inventory record not found.");
        }

        // Update the inventory record with the new values
        inventory.ArrivalDate = request.InventoryDTO.ArrivalDate;
        inventory.ExpirationDate = request.InventoryDTO.ExpirationDate;
        inventory.ManufacturingDate = request.InventoryDTO.ManufacturingDate;
        inventory.NumberOfUnits = request.InventoryDTO.NumberOfUnits;

        // Save changes to the database
        await _dbContext.SaveChangesAsync(cancellationToken);

        // Map the updated entity to a DTO and return it
        return _mapper.Map<InventoryDTO>(inventory);
    }
}
