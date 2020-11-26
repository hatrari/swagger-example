using System;
using System.Linq;
using System.Collections.Generic;
using Items.Models;
using Items.Contexts;

namespace Items.Persistence
{
  public class ItemRepository : IItemRepository
  {
    private readonly ItemsContext _context;
    public ItemRepository(ItemsContext context) => _context = context;
    public void Add(Item item)
    {
      _context.Add(item);
      _context.SaveChanges();
    }
    public IEnumerable<Item> GetAll() => _context.Items.ToList();
    public Item GetBy(Guid id) => _context.Items.FirstOrDefault(i => i.Id == id);
    public void Remove(Guid id)
    {
      Item item = GetBy(id);
      _context.Remove(item);
      _context.SaveChanges();
    }
    public void Update(Item item)
    {
      _context.Update(item);
      _context.SaveChanges();
    }
  }
}