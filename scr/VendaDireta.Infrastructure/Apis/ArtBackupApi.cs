using FastResults.Results;
using RestSharp;
using VendaDireta.Aplication.Contracts.Apis;
using VendaDireta.Aplication.Dto.ArtBackup;
using VendaDireta.Shared.Extensions;

namespace VendaDireta.Infrastructure.Apis;

public class ArtBackupApi : IArtBackupApi
{
    public async Task<BaseResult<ResponseArtBackupDto>> ObterRelatorio(CancellationToken cancellationToken)
    {
        RestClientOptions options =
            new RestClientOptions(
                "https://mspclouds.com/api/v1/cloudbackup/reports/summary?api_key=3012-3A23-B571-1EAB");
        RestClient client = new RestClient(options);
        var response = await client.GetAsync<ResponseArtBackupDto>(new RestRequest(string.Empty), cancellationToken);

        return ResponseExtension.Response(response);
    }
}