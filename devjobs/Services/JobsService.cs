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

    // public async Task<List<Job>> GetAsync() => await _jobsCollection.Find(_ => true).ToListAsync();
    public IMongoCollection<Job> Get() => _jobsCollection;
    // public Task<IQueryable<Job>> GetAsync() => _jobsCollection.Find(_ => true);

    public async Task<Job?> GetAsync(string id) => await _jobsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
}