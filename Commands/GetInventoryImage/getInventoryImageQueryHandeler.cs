
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class getInventoryImageQueryHandeler : IRequestHandler<getInventoryImageQuery, string>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public getInventoryImageQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<string> Handle(getInventoryImageQuery request, CancellationToken cancellationToken)
    {
 
        var imagePath =await this._dbContext.ShipmentImage.FirstOrDefaultAsync(x=>x.barcode==request._barcode);
            if(imagePath==null || imagePath.ImageURL == null){
                return null;
            }
        return imagePath.ImageURL;
    }
}
