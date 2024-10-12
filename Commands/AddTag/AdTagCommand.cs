using MediatR;


  public class AddTagCommand : IRequest<TagDTO>
  {
    public TagDTO _tag;
    public AddTagCommand(TagDTO tag)
    {
      _tag = tag;
    }
  }
