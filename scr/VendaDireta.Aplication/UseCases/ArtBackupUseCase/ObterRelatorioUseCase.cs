using FastResults.Results;
using MediatR;
using VendaDireta.Aplication.Abstractions;
using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Contracts.Apis;
using VendaDireta.Aplication.Dto.ArtBackup;
using VendaDireta.Aplication.Requests.ArtBackup;

namespace VendaDireta.Aplication.UseCases.ArtBackupUseCase;

public class ObterRelatorioUseCase(
    ISender sender,
    IArtBackupApi artBackupApi) :
    BaseUseCase<ObterRelatorioArtBackupRequest, RelatorioArtBackupDto>(sender)
{
    public override async Task<BaseResult<RelatorioArtBackupDto>> Handle(ObterRelatorioArtBackupRequest request,
        CancellationToken cancellationToken)
    {
        BaseResult<ResponseArtBackupDto> response = await artBackupApi.ObterRelatorio(cancellationToken);
        if (response.IsFailure)
        {
            return BaseResult.Failure<RelatorioArtBackupDto>(response.Error);
        }

        RelatorioArtBackupDto relatorio = new(response.Value);

        return relatorio;
    }
}