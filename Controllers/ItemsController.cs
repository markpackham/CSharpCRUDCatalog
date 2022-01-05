using System.Collections.Generic;
using CSharpCRUDCatalog.Entities;
using CSharpCRUDCatalog.Dtos;
using CSharpCRUDCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CSharpCRUDCatalog.Controllers
{

    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
         private readonly IInMemItemsRepository repository;

         public ItemsController(IInMemItemsRepository repository)
        {
             this.repository = repository;
         }

        // GET /items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        // POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            var exsitingItem = repository.GetItem(id);

            if(exsitingItem is null)
            {
                return NotFound();
            }

            // "with" allows us to use a copy of an immutable type & modify it
            Item updatedItem = exsitingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price,
            };

            repository.UpdateItem(updatedItem);

            return NoContent();
        }
    }
}