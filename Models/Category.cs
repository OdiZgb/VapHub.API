public class Category{
  public int Id{set;get;}
  public string Name{set;get;}
  public string Description{set;get;}
  public string? ImageURL{set;get;} = "";
  public ICollection<CategoryProperty> CategoryProperties{set;get;}
}