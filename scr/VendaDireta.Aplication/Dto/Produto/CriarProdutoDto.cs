namespace VendaDireta.Aplication.Dto.Produto;

public class CriarProdutoDto(Guid id)
{
    public string Link { get; set; } = $"/v1/Produto/id?{id}";
    public Guid Id { get; set; } = id;
}