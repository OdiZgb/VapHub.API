using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

public class EditInventoryQuantityCommandHandler : IRequestHandler<EditInventoryQuantityCommand, InventoryDTO>
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public EditInventoryQuantityCommandHandler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<InventoryDTO> Handle(EditInventoryQuantityCommand request, CancellationToken cancellationToken)
    {
        // Fetch the existing inventory record by ID
        var inventory = await _dbContext.Inventory
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (inventory == null)
        {
            throw new KeyNotFoundException("Inventory record not found.");
        }

        // Update only the NumberOfUnits field
        inventory.NumberOfUnits = request.QuantityDTO.NumberOfUnits;

        // Save changes to the database
        await _dbContext.SaveChangesAsync(cancellationToken);

        // Map the updated entity to a DTO and return it
        return _mapper.Map<InventoryDTO>(inventory);
    }
}
