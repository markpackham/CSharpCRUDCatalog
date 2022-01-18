using CSharpCRUDCatalog.Controllers;
using CSharpCRUDCatalog.Entities;
using CSharpCRUDCatalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Catalog.UnitTests;

public class ItemsControllerTests
{
    [Fact]
    public async Task GetItemAsync_WithUnexistingItem_ReturnsNotFound()
    {
        // Arrange
        var repositoryStub = new Mock<IInMemItemsRepository>();
        repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
        .ReturnsAsync((Item)null);

        var loggerStub = new Mock<ILogger<ItemsController>>();

        var controller = new ItemsController(repositoryStub.Object, loggerStub.Object);

        // Act
        var result = await controller.GetItemAsync(It.IsAny<Guid>());

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}