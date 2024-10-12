using MediatR;


  public class GetAllTagsQuery : IRequest<IEnumerable<TagDTO>>
  {
    public GetAllTagsQuery()
    {
    }
  }
