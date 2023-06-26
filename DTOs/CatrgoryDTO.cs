public class CategoryDTO{
  public int? Id{set;get;} =0;
  public string? Name{set;get;} = null;
  public string? Description{set;get;}
  public string?  ImageURL{set;get;} = "";
  public IFormFile? file{set;get;}

  public List<CategoryPropertyDTO>? CategoryPropertiesDTO{set;get;}
}