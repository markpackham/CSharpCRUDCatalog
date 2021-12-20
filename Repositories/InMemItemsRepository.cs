using System.Collections.Generic;
using CSharpCRUDCatalog.Entities;

namespace CSharpCRUDCatalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id=Guid.NewGuid(), Name = "Potion", Price = 5, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 15, CreatedDate = DateTimeOffset.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 10, CreatedDate = DateTimeOffset.UtcNow }
        };
    }
}