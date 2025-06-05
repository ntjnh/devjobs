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
        var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI");
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase("devjobs");

        _jobsCollection = mongoDatabase.GetCollection<Job>("jobs");
    }

    public IMongoCollection<Job> GetJobs() => _jobsCollection;

    public async Task<Job?> GetJobAsync(string id) => await _jobsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
}