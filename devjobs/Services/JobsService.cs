using devjobs.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace devjobs.Services;

public class JobsService
{
    private readonly IMongoCollection<Job> _jobsCollection;

    public JobsService(
        IOptions<JobsDatabaseSettings> jobsDatabaseSettings)
    {
        var mongoClient = new MongoClient(jobsDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(jobsDatabaseSettings.Value.DatabaseName);

        _jobsCollection = mongoDatabase.GetCollection<Job>(jobsDatabaseSettings.Value.JobsCollectionName);
    }

    public IMongoCollection<Job> GetJobs() => _jobsCollection;

    public async Task<Job?> GetJobAsync(string id) => await _jobsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
}