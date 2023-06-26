using MediatR;
using Models;

  public class GetCurrentQuantitesQuery : IRequest<IEnumerable<ItemQuantityDTO>>
  {
    public GetCurrentQuantitesQuery()
    {
    }
  }
