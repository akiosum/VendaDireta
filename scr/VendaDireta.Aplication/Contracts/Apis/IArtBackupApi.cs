using FastResults.Results;
using VendaDireta.Aplication.Dto.ArtBackup;
using VendaDireta.Domain.Contracts.Abstractions;

namespace VendaDireta.Aplication.Contracts.Apis;

public interface IArtBackupApi : IInfrastructure
{
    Task<BaseResult<ResponseArtBackupDto>> ObterRelatorio(CancellationToken cancellationToken);
}