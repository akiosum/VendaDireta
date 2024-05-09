namespace VendaDireta.Aplication.Dto.ArtBackup;

public class RelatorioArtBackupDto()
{
    public RelatorioArtBackupDto(ResponseArtBackupDto response) : this()
    {
        Empresa = new EmpresaArtBackupDto(response);
        Status = new StatusDoBackupDto(response.Status);
        TiposDeBackup = GerarTiposDeBackup(response);
    }

    public EmpresaArtBackupDto Empresa { get; private set; } = new(new());
    public StatusDoBackupDto Status { get; private set; } = new(new());
    public List<TipoDeBackupDto> TiposDeBackup { get; private set; } = GerarTiposDeBackup(new());

    private static List<TipoDeBackupDto> GerarTiposDeBackup(ResponseArtBackupDto response)
    {
        if (!response.Clients.Any())
        {
            return new List<TipoDeBackupDto>();
        }

        List<TipoDeBackupDto> tiposDeBackup = [];
        response.Clients.ForEach(
            tipo => tiposDeBackup.Add(new TipoDeBackupDto(tipo)));

        return tiposDeBackup;
    }
}

public class EmpresaArtBackupDto(ResponseArtBackupDto response)
{
    public long Id { get; set; } = response.Company.Id;
    public string Nome { get; set; } = response.Company.Name;
    public string Tipo { get; set; } = response.Company.Type;
}

public class StatusDoBackupDto(StatusDto status)
{
    public int Informativos { get; set; } = status.Info;
    public int Sucessos { get; set; } = status.Success;
    public int Avisos { get; set; } = status.Warning;
    public int Erros { get; set; } = status.Error;
    public int Total { get; set; } = status.Total;
}

public class TipoDeBackupDto(TypeBackupDto type)
{
    public long Id { get; set; } = type.Id;
    public string Nome { get; set; } = type.Name;

    public StatusDoBackupDto Status { get; set; } = new(type.Status);
    public List<ClienteBackupDto> Clientes { get; set; } = GerarClientesDeBackup(type.Clients);

    private static List<ClienteBackupDto> GerarClientesDeBackup(List<ClientDto> client)
    {
        if (!client.Any())
        {
            return [];
        }

        List<ClienteBackupDto> clientes = [];
        client.ForEach(
            cliente => clientes.Add(new ClienteBackupDto(cliente)));

        return clientes;
    }
}

public class ClienteBackupDto(ClientDto client)
{
    public long Id { get; set; } = client.Id;
    public string Nome { get; set; } = client.Name;
    public StatusDoBackupDto Status { get; set; } = new(client.Status);
    public List<LogDeBackupDto> LogDeBackup { get; set; } = GerarLogs(client.Backupsets);

    private static List<LogDeBackupDto> GerarLogs(List<BackupLogDto> backups)
    {
        if (!backups.Any())
        {
            return [];
        }

        List<LogDeBackupDto> logs = [];
        backups.ForEach(
            log => logs.Add(new LogDeBackupDto(log)));

        return logs;
    }
}

public class LogDeBackupDto(BackupLogDto log)
{
    public string Status { get; set; } = log.Status;
    public string Login { get; set; } = log.Login_name;
    public string Destinatario { get; set; } = log.Destination_name;
    public DateTime UltimoBackup { get; set; } = Convert.ToDateTime(log.Last_backup_job_date);
    public DateTime UltimoBackupDeSucesso { get; set; } = Convert.ToDateTime(log.Last_success_backup_job_date);
    public string Descricao { get; set; } = log.Last_backup_job_status_description;
}