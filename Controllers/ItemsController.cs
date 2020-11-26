using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Items.Persistence;
using Items.Models;

namespace Items.Controllers
{
  [Route("api/[controller]")]
  public class ItemsController : Controller
  {
    private readonly IItemRepository _itemRepository;
    public ItemsController(IItemRepository itemRepository) => _itemRepository = itemRepository;

    [HttpGet]
    public IEnumerable<Item> Get() => _itemRepository.GetAll().ToList();

    [HttpGet]
    [Route("{id}")]
    public Item Get(int id) => _itemRepository.GetBy(id);

    [HttpPost]
    public IActionResult Post([FromBody] Item item)
    {
      if (item == null)
          return BadRequest();
      
      _itemRepository.Add(item);

      return StatusCode(201, Json(true));
    }

    [HttpPut]
    public IActionResult Update([FromBody] Item item)
    {
      Item oldItem = _itemRepository.GetBy(item.Id);
      if (oldItem == null)
          return NotFound();

      _itemRepository.Update(item);
      return new NoContentResult();
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
      Item item = _itemRepository.GetBy(id);
      if (item == null)
          return NotFound();

      _itemRepository.Remove(id);
      return new NoContentResult();
    }
  }
}