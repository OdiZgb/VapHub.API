using MediatR;

  public class DeleteFromQuantitesQuery : IRequest<IEnumerable<ItemQuantityDTO>>
  {
    public DeleteFromQuantitesQuery()
    {
    }
  }
