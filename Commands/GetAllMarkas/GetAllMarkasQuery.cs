using MediatR;


  public class GetAllMarkasQuery : IRequest<IEnumerable<MarkaDTO>>
  {
    public GetAllMarkasQuery()
    {
    }
  }


