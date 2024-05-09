namespace VendaDireta.Aplication.Dto.ArtBackup;

public class ResponseArtBackupDto
{
    public CompanyDto Company { get; set; } = new CompanyDto();

    public StatusDto Status { get; set; } = new StatusDto();

    public List<TypeBackupDto> Clients { get; set; } = new();
}

public class CompanyDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
}

public class StatusDto
{
    public int Info { get; set; }
    public int Success { get; set; }
    public int Warning { get; set; }
    public int Error { get; set; }
    public int Total { get; set; }
}

public class TypeBackupDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public StatusDto Status { get; set; } = new StatusDto();
    public List<ClientDto> Clients { get; set; } = new();
}

public class ClientDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public StatusDto Status { get; set; } = new StatusDto();
    public List<BackupLogDto> Backupsets { get; set; } = new();
}

public class BackupLogDto
{
    public string Status { get; set; } = string.Empty;
    public string Login_name { get; set; } = string.Empty;
    public string Destination_name { get; set; } = string.Empty;
    public string Last_backup_job_date { get; set; } = string.Empty;
    public string Last_success_backup_job_date { get; set; } = string.Empty;
    public string Last_backup_job_status_description { get; set; } = string.Empty;
}