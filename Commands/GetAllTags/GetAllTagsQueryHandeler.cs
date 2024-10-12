
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllTagsQueryHandeler : IRequestHandler<GetAllTagsQuery, IEnumerable<TagDTO>>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetAllTagsQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<IEnumerable<TagDTO>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {

        List<Tag> tags = await _dbContext.Tags.ToListAsync();
        return _mapper.Map<List<TagDTO>>(tags);
    }
}