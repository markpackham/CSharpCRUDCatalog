﻿using CSharpCRUDCatalog.Entities;

namespace CSharpCRUDCatalog.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItemAsync(Guid id);
        IEnumerable<Item> GetItemsAsync();

        void CreateItemAsync(Item item);

        void UpdateItemAsync(Item item);

        void DeleteItemAsync(Guid id);
    }
}