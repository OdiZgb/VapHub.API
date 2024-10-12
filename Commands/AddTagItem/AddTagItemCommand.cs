using MediatR;


  public class AddTagItemCommand : IRequest<TagItemDTO>
  {
    public TagItemDTO _tagItemDTO;
    public AddTagItemCommand(TagItemDTO tagItemDTO)
    {
      _tagItemDTO = tagItemDTO;
    }
  }
