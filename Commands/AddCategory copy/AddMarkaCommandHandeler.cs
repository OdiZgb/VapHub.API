using Data;
using MediatR;
  public class AddMarkaCommandHandeler : IRequestHandler<AddMarkaCommand, MarkaDTO>
  {
    public AppDbContext _dbContext { set; get; }
    public AddMarkaCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<MarkaDTO> Handle(AddMarkaCommand request, CancellationToken cancellationToken)
    {

      var marka = new Marka
      {
        Name = request._markaDTO.Name,
        Description = request._markaDTO.Description,
      };

      _dbContext.Marka.Add(marka);
      await _dbContext.SaveChangesAsync(cancellationToken);


      return new MarkaDTO
      {
        Id=marka.Id,
        Description = marka.Description,
        Name = marka.Name,
      };
    }
  }