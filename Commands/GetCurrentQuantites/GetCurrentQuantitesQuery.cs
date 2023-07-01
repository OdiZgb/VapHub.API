using MediatR;

  public class GetCurrentQuantitesQuery : IRequest<IEnumerable<ItemQuantityDTO>>
  {
    public GetCurrentQuantitesQuery()
    {
    }
  }
