using MediatR;

  public class AddCategoryCommand : IRequest<CategoryDTO>
  {
    public CategoryDTO _categoryDTO;
    public AddCategoryCommand(CategoryDTO categoryDTO)
    {
      _categoryDTO = categoryDTO;
    }
  }