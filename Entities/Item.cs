using System;

namespace CSharpCRUDCatalog.Entities
{
    // We use "record" instead of "class" so it will be immutable
    public record Item
    {
        // we want to use "init" instead of "set" so it can't be modified after creation
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
