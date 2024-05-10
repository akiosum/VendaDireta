using VendaDireta.Domain.Contracts.Repositories;
using VendaDireta.Domain.Entities;
using VendaDireta.Infrastructure.Abstractions;
using VendaDireta.Infrastructure.Data;

namespace VendaDireta.Infrastructure.Repositories;

public class VendaRepository(VendaDiretaContext context) :
    BaseReporitory<Venda>(context),
    IVendaRepository
{
    public void InserirSemSave(Venda venda)
    {
        context.Venda.Add(venda);
    }
}