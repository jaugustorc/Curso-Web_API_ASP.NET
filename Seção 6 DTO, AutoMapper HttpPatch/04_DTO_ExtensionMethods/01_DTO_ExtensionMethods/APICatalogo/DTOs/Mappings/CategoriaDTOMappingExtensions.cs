using APICatalogo.Models;

namespace APICatalogo.DTOs.Mappings;

public static class CategoriaDTOMappingExtensions
{
    //CategoriaDTO? indica que uma variável do tipo CategoriaDTO? pode conter uma instância
    //de CategoriaDTO ou um valor nulo.(Veja detalhes no proximo método)
    public static CategoriaDTO? ToCategoriaDTO(this Categoria categoria)
    {
        if (categoria is null)
        {
            return null;
        }

        return new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        };
    }

    // Categoria? indica que Categoria é um tipo anulável ou seja
    // uma variável do tipo Categoria? pode armazenar uma instância de Categoria
    // ou um valor nulo (null). Isso é útil quando, por exemplo, você está convertendo
    // de um objeto de domínio para um DTO e deseja indicar que, se o objeto de domínio
    // for nulo, o DTO resultante também será nulo. Isso evita erros de referência nula.
    public static Categoria? ToCategoria(this CategoriaDTO categoriaDto)
    {
        if (categoriaDto is null)
        {
            return null;
        }

        return new Categoria
        {
            CategoriaId = categoriaDto.CategoriaId,
            Nome = categoriaDto.Nome,
            ImagemUrl = categoriaDto.ImagemUrl
        };
    }
    public static IEnumerable<CategoriaDTO> ToCategoriaDTOList(this IEnumerable<Categoria> categorias)
    {
        // - categorias is null: verifica se a variável categorias é nula.
        // Se categorias for nulo, significa não existe uma lista de categorias disponível
        // - !categorias.Any(): usa o método Any() para verificar se a lista categorias não contém
        // nenhum elemento. O método Any() retorna true se houver pelo menos um elemento na lista
        // e false se a lista estiver vazia.
        // - O operador || (OU)combina as duas condições acima.
        // Se categorias for nulo ou estiver vazio, a condição completa se tornará verdadeira.
        // Se a condição for verdadeira(ou seja, categorias for nulo ou vazio), a instrução
        // dentro do bloco será executada retornando uma nova lista vazia de CategoriaDTO
        //---------------------------------------------------------------------
        if (categorias is null || !categorias.Any())
        {
            return new List<CategoriaDTO>();
        }

        //  categorias: é uma lista de objetos da entidade Categoria.
        // .Select(categoria => new CategoriaDTO { ... }): O método Select é usado para projetar
        // cada objeto da lista categorias em um novo objeto CategoriaDTO. Para cada categoria na
        // lista, estamos criando um novo objeto CategoriaDTO e definindo suas propriedades
        // usando a sintaxe de inicialização de objeto:
        // - CategoriaId = categoria.CategoriaId: Isso está mapeando a propriedade CategoriaId do
        // objeto categoria para a propriedade CategoriaId do objeto CategoriaDTO.
        // - Nome = categoria.Nome: Isso está mapeando a propriedade Nome do objeto categoria para
        // a propriedade Nome do objeto CategoriaDTO.
        // - ImagemUrl = categoria.ImagemUrl: Isso está mapeando a propriedade ImagemUrl do objeto
        // categoria para a propriedade ImagemUrl do objeto CategoriaDTO.
        // .ToList(): O método ToList converte a sequência de objetos resultante da projeção
        // Select em uma lista.Portanto, o resultado final é uma lista de objetos CategoriaDTO
        // que corresponde aos objetos da lista original categorias, com as propriedades mapeadas
        // ----------------------------------------------------------------------------------------
        return categorias.Select(categoria => new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImagemUrl = categoria.ImagemUrl
        }).ToList();
    }
}
