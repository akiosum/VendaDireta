using VendaDireta.Domain.Contracts.Abstractions;
using VendaDireta.Domain.Entities;

namespace VendaDireta.Domain.Contracts.Repositories;

public interface IVendaRepository: IBaseRepository<Venda>
{
    void InserirSemSave(Venda venda);
}