
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetTagQueryHandeler : IRequestHandler<GetTagQuery, TagDTO>
{
  private IMapper _mapper;
  public AppDbContext _dbContext { set; get; }

  public GetTagQueryHandeler(AppDbContext dbContext, IMapper mapper)
  {
    _mapper = mapper;
    _dbContext = dbContext;
  }

    public async Task<TagDTO> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {

        Tag? tag = await _dbContext.Tags.Where(x => x.Id == request.tagId).FirstOrDefaultAsync();
        return _mapper.Map<TagDTO>(tag);
    }
}