using Microsoft.EntityFrameworkCore;

namespace Data{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
    {
    }
    public DbSet<Item> Items { get; set; }
    public DbSet<ParentChildItem> ParentChildItems { get; set; }
    public DbSet<PriceIn> PriceIn { get; set; }
    public DbSet<PriceOut> PriceOut { get; set; }
    public DbSet<ItemImage> ItemsImages { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<ExpenseItem> ExpenseItems { get; set; }
    public DbSet<Marka> Marka { get; set; }
    public DbSet<Inventory> Inventory  { get; set; }
    public DbSet<HistoryOfCashBill> HistoryOfCashBill  { get; set; }
    public DbSet<CategoryProperty> CategoryProperty { get; set; }
    public DbSet<ShipmentImage> ShipmentImage { get; set; }
    public DbSet<Trader> Traders { get; set; }
    public DbSet<Salary> Salarys { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Bill> Bills { get; set; }
    public DbSet<ClientDebt> ClientDebts { get; set; }
    public DbSet<User> Users { get; set; }

  }
}