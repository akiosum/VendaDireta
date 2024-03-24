using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.Receita;
using VendaDireta.Aplication.Patterns.Builders;

namespace VendaDireta.Aplication.Contracts.Patterns;

public interface IReceitaBuilder : IPatterns
{
    ReceitaBuilder Iniciar(CriarReceitaDto criarReceita);

    ReceitaBuilder AdicionarData();

    ReceitaBuilder AdicionarValores();

    ReceitaBuilder AdicionarDocumento();

    List<ReceitaDto> Buildar();
}