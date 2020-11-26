using Items.Models;
using Microsoft.EntityFrameworkCore;

namespace Items.Contexts
{
  public class ItemsContext : DbContext
  {
    public ItemsContext(DbContextOptions<ItemsContext>options) : base(options)
    { }
    public DbSet<Item> Items { get; set; }
  }
}