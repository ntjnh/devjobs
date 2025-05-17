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
        bool FullTime,
        int? pageNumber)
    { 
        var jobs = _jobsService.Get();
        var viewModel = new JobsViewModel();
        var builder = Builders<Job>.Filter;
        var filter = builder.Empty;
        var results = jobs.Find(filter);

        // If keyword/location has been entered or Full Time is checked then 
        // set page number to 1
        if (!string.IsNullOrEmpty(keyword) ||
            !string.IsNullOrEmpty(location) ||
            FullTime)
        {
            pageNumber = 1;
        }

        if (!string.IsNullOrEmpty(keyword))
        {
            // jobs = jobs.Where(j => {
            //     var checkPosition = j.Position.Contains(keyword, StringComparison.CurrentCultureIgnoreCase);
            //     var checkCompany = j.Company.Contains(keyword, StringComparison.CurrentCultureIgnoreCase);

            //     return checkPosition || checkCompany;

            // }).ToList();
            filter = builder.Eq(j => j.Position, keyword) | builder.Eq(j => j.Company, keyword);
            results = jobs.Find(filter);
        }

        if (!string.IsNullOrEmpty(location))
        {
            // jobs = jobs.Where(j => j.Location.ToLower().Contains(location.ToLower())).ToList();
            filter = builder.Eq(j => j.Location.ToLower(), location.ToLower());
            results = jobs.Find(filter);
        }

        if (FullTime)
        {
            // jobs = jobs.Where(j => j.Contract == "Full Time").ToList();
            filter = builder.Eq(j => j.Contract, "Full Time");
            results = jobs.Find(filter);
        }

        viewModel.Jobs = results.ToList();


        // int pageSize = 9;
        // var jobsQ = _jobsService.GetQueryable();
        // var xyz = await PaginatedList<Job>.CreateAsync(jobsQ, pageNumber ?? 1, pageSize);

        return View(viewModel);
    }

    [Route("/Jobs/{id?}")]
    public async Task<IActionResult> Job(string id)
    {
        var job = await _jobsService.GetAsync(id);

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
