using CSharpCRUDCatalog.Repositories;
using Moq;
using Xunit;

namespace Catalog.UnitTests;

public class ItemsControllerTests
{
    [Fact]
    public void GetItemAsync_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        var repositoryStub = new Mock<IInMemItemsRepository>();

        // Act

        // Assert
    }
}