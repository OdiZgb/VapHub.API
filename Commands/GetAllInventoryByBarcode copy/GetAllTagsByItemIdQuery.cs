using MediatR;


  public class GetAllTagsByItemIdQuery : IRequest<IEnumerable<TagItemDTO>>
  {
    public int _ItemId ;
    public GetAllTagsByItemIdQuery(int ItemId)
    {
      this._ItemId = ItemId;
    }
  }
