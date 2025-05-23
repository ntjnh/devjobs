using System.Text.RegularExpressions;
using devjobs.Models;
using devjobs.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace devjobs.Controllers;

public class JobsController : Controller
{
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService) => _jobsService = jobsService;

    [Route("Jobs")]
    public async Task<IActionResult> Index(
        string? keyword, 
        string? location, 
        bool FullTime)
    { 
        var jobs = _jobsService.GetJobs();
        var viewModel = new JobsViewModel();
        var builder = Builders<Job>.Filter;

        // Filters
        var baseFilter = builder.Empty;
        var ftFilter = baseFilter;
        var keywordFilter = baseFilter;
        var locationFilter = baseFilter;
        
        var results = await jobs.FindAsync(baseFilter);

        var keywordEntered = false;
        var locationEntered = false;

        if (FullTime)
        {
            ftFilter = builder.Eq(j => j.Contract, "Full Time");
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            keywordEntered = true;
            keywordFilter = builder.Regex(
                j => j.Position, new Regex(keyword, RegexOptions.IgnoreCase)) |
                builder.Regex(j => j.Company, new Regex(keyword, RegexOptions.IgnoreCase));
        }

        if (!string.IsNullOrEmpty(location))
        {
            locationEntered = true;
            locationFilter = builder.Regex(
                j => j.Location, new Regex(location, RegexOptions.IgnoreCase));
        }

        if (FullTime || keywordEntered || locationEntered)
        {
            results = await jobs.FindAsync(ftFilter & keywordFilter & locationFilter);
        }

        var searchResults = results.ToList();
        viewModel.Jobs = searchResults;
        return View(viewModel);
    }

    [Route("/Jobs/{id?}")]
    public async Task<IActionResult> Job(string id)
    {
        var job = await _jobsService.GetJobAsync(id);

        if (job is null)
        {
            return NotFound();
        }

        var viewModel = new JobViewModel
        {
            JobDescription = job
        };

        return View("Job", viewModel);
    }
}
