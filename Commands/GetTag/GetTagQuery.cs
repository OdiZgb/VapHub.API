using MediatR;


  public class GetTagQuery : IRequest<TagDTO>
  {
    public int tagId;
    public GetTagQuery(int _tagId)
    {
      tagId = _tagId;
    }
  }
