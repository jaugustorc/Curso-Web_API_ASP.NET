using APICatalogo.Controllers;
using APICatalogo.DTOs;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoxUnitTests.UnitTests;

public class PutProdutoUnitTests : IClassFixture<ProdutosUnitTestController>
{
    private readonly ProdutosController _controller;

    public PutProdutoUnitTests(ProdutosUnitTestController controller)
    {
        _controller = new ProdutosController(controller.repository, controller.mapper);
    }

    //testes de unidade para PUT
    [Fact]
    public async Task PutProduto_Return_OkResult()
    {
        //Arrange  
        var prodId = 14;

        var updatedProdutoDto = new ProdutoDTO
        {
            ProdutoId = prodId,
            Nome = "Produto Atualizado - Testes",
            Descricao = "Minha Descricao",
            ImagemUrl = "imagem1.jpg",
            CategoriaId = 2
        };

        // Act
        var result = await _controller.Put(prodId, updatedProdutoDto) as ActionResult<ProdutoDTO>;

        // Assert  
        result.Should().NotBeNull(); // Verifica se o resultado não é nulo
        result.Result.Should().BeOfType<OkObjectResult>(); // Verifica se o resultado é OkObjectResult
    }

    [Fact]
    public async Task PutProduto_Return_BadRequest()
    {
        //Arrange
        var prodId = 1000;

        var meuProduto = new ProdutoDTO
        {
            ProdutoId = 14,
            Nome = "Produto Atualizado - Testes",
            Descricao = "Minha Descricao alterada",
            ImagemUrl = "imagem11.jpg",
            CategoriaId = 2
        };

        //Act              
        var data = await _controller.Put(prodId, meuProduto);

        // Assert  
        data.Result.Should().BeOfType<BadRequestResult>().Which.StatusCode.Should().Be(400);

    }
}
