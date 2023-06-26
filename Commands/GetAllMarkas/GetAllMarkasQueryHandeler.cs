using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class GetAllMarkasQueryHandeler : IRequestHandler<GetAllMarkasQuery, IEnumerable<MarkaDTO>>
{
    public AppDbContext _dbContext { set; get; }
    public GetAllMarkasQueryHandeler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<MarkaDTO>> Handle(GetAllMarkasQuery request, CancellationToken cancellationToken)
    {

        List<Marka> markas = await _dbContext.Marka.ToListAsync();
        List<MarkaDTO> markasDTO = new List<MarkaDTO>();
        foreach (Marka marka in markas)
        {
            MarkaDTO markaDTO = new MarkaDTO()
            {
                Id = marka.Id,
                Description = marka.Description,
                Name = marka.Name,
            };
            markasDTO.Add(markaDTO);
        }
        return markasDTO;
    }
}
