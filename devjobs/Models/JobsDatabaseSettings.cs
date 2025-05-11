namespace devjobs.Models;

public class JobsDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string JobsCollectionName { get; set; } = null!;
}
