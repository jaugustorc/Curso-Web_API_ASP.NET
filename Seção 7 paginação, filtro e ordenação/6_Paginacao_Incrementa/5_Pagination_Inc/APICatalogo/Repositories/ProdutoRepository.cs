using APICatalogo.Context;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{
    public ProdutoRepository(AppDbContext context): base(context)
    {       
    }

    //public IEnumerable<Produto> GetProdutos(ProdutosParameters produtosParams)
    //{
    //    return GetAll()
    //        .OrderBy(p => p.Nome)
    //        .Skip((produtosParams.PageNumber - 1) * produtosParams.PageSize)
    //        .Take(produtosParams.PageSize).ToList();

    //}
    public PagedList<Produto> GetProdutos(ProdutosParameters produtosParameters)
    {
        //IQueryable<T> é apropriado quando você deseja realizar consultas de forma
        //eficiente em uma fonte de dados que pode ser consultada diretamente, como
        //um banco de dados. Ele suporta a consulta diferida e permite que as
        //consultas sejam traduzidas em consultas SQL eficientes quando você está
        //trabalhando com um provedor de banco de dados, como o Entity Framework.
        //------------------------------------------------------------------------
        //IEnumerable<T> é uma interface mais geral que representa uma coleção de
        //objetos em memória. Ela não oferece suporte a consultas diferidas ou tradução
        //de consultas SQL. Isso significa que, ao usar IEnumerable, você primeiro traz
        //todos os dados para a memória e, em seguida, aplica consultas, o que pode ser
        //menos eficiente para grandes conjuntos de dados.
        var produtos = GetAll().OrderBy(p => p.ProdutoId).AsQueryable();

        var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos, 
                   produtosParameters.PageNumber, produtosParameters.PageSize);
        
        return produtosOrdenados;
    }


    public IEnumerable<Produto> GetProdutosPorCategoria(int id)
    {
        return GetAll().Where(c => c.CategoriaId == id);
    }
}

