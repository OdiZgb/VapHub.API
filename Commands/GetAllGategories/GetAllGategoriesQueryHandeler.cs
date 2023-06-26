using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;


public class GetAllGategoriesQueryHandeler : IRequestHandler<GetAllGategoriesQuery, IEnumerable<CategoryDTO>>
{
    public AppDbContext _dbContext { set; get; }
    public GetAllGategoriesQueryHandeler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<CategoryDTO>> Handle(GetAllGategoriesQuery request, CancellationToken cancellationToken)
    {

        List<Category> categories = await _dbContext.Category.Include(e => e.CategoryProperties).ToListAsync();
        List<CategoryDTO> categoriesDTO = new List<CategoryDTO>();
        foreach (Category category in categories)
        {
            List<CategoryPropertyDTO> categoryPropertiesDTO = new List<CategoryPropertyDTO>();
            foreach (CategoryProperty categoryProperty in category.CategoryProperties)
            {
                categoryPropertiesDTO.Add(
                    new CategoryPropertyDTO()
                    {
                        CategoryId = categoryProperty.Id,
                        Id = categoryProperty.Id,
                        Name = categoryProperty.Name
                    }
                    );
            }
            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Description = category.Description,
                Name = category.Name,
                CategoryPropertiesDTO = categoryPropertiesDTO
            };
            categoriesDTO.Add(categoryDTO);
        }
        return categoriesDTO;
    }
}
