using VendaDireta.Aplication.Abstractions.Contracts;
using VendaDireta.Aplication.Dto.ArtBackup;

namespace VendaDireta.Aplication.Requests.ArtBackup;

public record ObterRelatorioArtBackupRequest() : IRequestUseCase<RelatorioArtBackupDto>;