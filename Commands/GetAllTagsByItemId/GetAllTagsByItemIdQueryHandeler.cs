
using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

public class GetAllTagsByItemIdQueryHandeler : IRequestHandler<GetAllTagsByItemIdQuery, IEnumerable<TagItemDTO>>
{
    private readonly IMapper _mapper;
    public AppDbContext _dbContext { set; get; }
    private readonly IMediator _mediator;
    public GetAllTagsByItemIdQueryHandeler(AppDbContext dbContext, IMediator mediator, IMapper mapper)
    {
        _dbContext = dbContext;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TagItemDTO>> Handle(GetAllTagsByItemIdQuery request, CancellationToken cancellationToken)
    {
        List<TagItem> inventories = await _dbContext.TagItems.Where(x => x.ItemId == request._ItemId).ToListAsync();
        var a = _mapper.Map<List<TagItemDTO>>(inventories);

        foreach (var TagItem in a)
        {
            TagItem.TagName  ="loading...";
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(x=>x.Id==TagItem.TagId);
            TagItem.TagName = tag.Title;
        }

        return a;
    }
}
