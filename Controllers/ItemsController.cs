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
            var items = repository.GetItems().Select(item => new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreatedDate = item.CreatedDate,
            });
            return items;
        }

        // GET /items/{id}
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }
    }
}