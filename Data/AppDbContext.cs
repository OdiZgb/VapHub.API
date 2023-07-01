using Microsoft.EntityFrameworkCore;
using Models;

namespace Data{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
    }
    public DbSet<Item> Items { get; set; }
    public DbSet<PriceIn> PriceIn { get; set; }
    public DbSet<PriceOut> PriceOut { get; set; }
    public DbSet<ItemImage> ItemsImages { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Marka> Marka { get; set; }
    public DbSet<Inventory> Inventory  { get; set; }
    public DbSet<CategoryProperty> CategoryProperty { get; set; }
    public DbSet<Trader> Traders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
  }
}