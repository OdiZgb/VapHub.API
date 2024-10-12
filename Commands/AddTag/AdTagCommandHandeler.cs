
using AutoMapper;
using Data;
using MediatR;
public class AddTagCommandHandeler : IRequestHandler<AddTagCommand, TagDTO>
{
    public AppDbContext _dbContext { set; get; }
    private readonly IMapper _mapper;
    public AddTagCommandHandeler(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<TagDTO> Handle(AddTagCommand request, CancellationToken cancellationToken)
    {
        var tag = _mapper.Map<Tag>(request._tag);

        var tagDB = _dbContext.Tags.Add(tag);
        await _dbContext.SaveChangesAsync(cancellationToken);
 
        return _mapper.Map<TagDTO>(tag);
    }
}
