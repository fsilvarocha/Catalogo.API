using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Catalogo.API.Models;

public class Categoria
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    [JsonIgnore]
    public ICollection<Produto>? Produtos { get; set; }

}
