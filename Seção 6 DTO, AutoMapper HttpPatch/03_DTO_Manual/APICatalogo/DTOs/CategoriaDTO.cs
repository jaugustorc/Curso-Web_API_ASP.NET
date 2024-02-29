using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }

    //Essas anotações são usadas para garantir que os dados inseridos no DTO CategoriaDTO
    //atendam a certos critérios de validação, como serem obrigatórios e terem comprimentos
    //máximos especificados. Isso ajuda a garantir que os dados inseridos sejam válidos e
    //atendam aos requisitos específicos da sua aplicação.
    [Required]
    [StringLength(80)]
    public string? Nome { get; set; }

    //A declaração string? é uma parte das características introduzidas no C# 8.0
    //para tornar os tipos de referência mais seguros em relação a valores nulos.
    //Isso ajuda a evitar exceções de referência nula, pois você precisa verificar
    //explicitamente se a propriedade Nome é nula antes de acessá-la.
    //Essa verificação pode ser feita usando um condicional if
    //ou o operador de coalescência nula (??).
    // Ex: string nomeNaoNulo = nome ?? "Nome Padrão"; 
    // Se nome for nulo, nomeNaoNulo receberá "Nome Padrão"
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

}
