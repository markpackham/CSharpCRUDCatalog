using CSharpCRUDCatalog.Entities;

namespace CSharpCRUDCatalog.Repositories
{
    public interface IInMemItemsRepository
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}