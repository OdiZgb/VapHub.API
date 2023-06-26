using MediatR;


  public class GetAllGategoriesQuery : IRequest<IEnumerable<CategoryDTO>>
  {
    public GetAllGategoriesQuery()
    {
    }
  }


