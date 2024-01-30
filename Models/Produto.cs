using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Swashbuckle.AspNetCore.Annotations;

namespace Catalogo.API.Models;

public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public Decimal? Preco { get; set; }
    public string? Imagem { get; set; }
    public DateTime DataCompra { get; set; }
    public int? QtdeEstoque { get; }
    public int CategoriaId { get; set; }
    [JsonIgnore]
    public Categoria? Categoria { get; set; }

}
