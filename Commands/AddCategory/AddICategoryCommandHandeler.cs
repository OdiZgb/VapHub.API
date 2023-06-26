using Data;
using MediatR;
  public class AddICategoryCommandHandeler : IRequestHandler<AddCategoryCommand, CategoryDTO>
  {
    public AppDbContext _dbContext { set; get; }
    public AddICategoryCommandHandeler(AppDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public async Task<CategoryDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {

      List<CategoryProperty> categoryProperties = new List<CategoryProperty>();
      foreach(CategoryPropertyDTO categoryPropertyDTO in request._categoryDTO.CategoryPropertiesDTO){
        categoryProperties.Add(new CategoryProperty{
         Name = categoryPropertyDTO.Name
        });
      }
      var category = new Category
      {
        Name = request._categoryDTO.Name,
        Description = request._categoryDTO.Description,
        CategoryProperties = categoryProperties
      };

      _dbContext.Category.Add(category);
      await _dbContext.SaveChangesAsync(cancellationToken);

      List<CategoryPropertyDTO> CategoryPropertyDTO = new List<CategoryPropertyDTO>();
      foreach(CategoryProperty categoryProperty in category.CategoryProperties){
        CategoryPropertyDTO.Add(new CategoryPropertyDTO{
         Id = categoryProperty.Id,
         Name = categoryProperty.Name,
        });
      }
      return new CategoryDTO
      {
        Id=category.Id,
        Description = category.Description,
        Name = category.Name,
        CategoryPropertiesDTO = CategoryPropertyDTO
      };
    }
  }