using APICatalogo.Controllers;
using APICatalogo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoxUnitTests.UnitTests;

public class DeleteProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
{
    private readonly ProdutosController _controller;

    public DeleteProdutoUnitTests(ProdutosUnitTestController controller)
    {
        _controller = new ProdutosController(controller.repository, controller.mapper);
    }

    //testes para o Delete
    [Fact]
    public async Task DeleteProdutoById_Return_OkResult()
    {
        var prodId = 3;

        // Act
        var result = await _controller.Delete(prodId) as ActionResult<ProdutoDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<OkObjectResult>(); // Verifica se o resultado é OkResult
    }

    [Fact]
    public async Task DeleteProdutoById_Return_NotFound()
    {
        // Arrange  
        var prodId = 999;

        // Act
        var result = await _controller.Delete(prodId) as ActionResult<ProdutoDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<NotFoundObjectResult>(); // Verifica se o resultado é NotFoundResult

    }
}
