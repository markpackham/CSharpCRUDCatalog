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
    }
}