using System;
using System.Collections.Generic;
using Items.Models;

namespace Items.Persistence
{
  public interface IItemRepository
  {
    void Add(Item item);
    IEnumerable<Item> GetAll();
    Item GetBy(Guid id);
    void Remove(Guid id);
    void Update(Item item);
  }
}