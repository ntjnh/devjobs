using devjobs.Models;
using devjobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace devjobs.Controllers;

public class JobsController : Controller
{
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService) => _jobsService = jobsService;

    [Route("Jobs")]
    public async Task<IActionResult> Index(string? keyword, string? location, bool FullTime)
    { 
        var jobs = await _jobsService.GetAsync();

        var viewModel = new JobsViewModel();

        if (!string.IsNullOrEmpty(keyword))
        {
            jobs = jobs.Where(j => {
                var checkPosition = j.Position.Contains(keyword, StringComparison.CurrentCultureIgnoreCase);
                var checkCompany = j.Company.Contains(keyword, StringComparison.CurrentCultureIgnoreCase);

                return checkPosition || checkCompany;

            }).ToList();
        }

        if (!string.IsNullOrEmpty(location))
        {
            jobs = jobs.Where(j => j.Location.ToLower().Contains(location.ToLower())).ToList();
        }

        if (FullTime)
        {
            jobs = jobs.Where(j => j.Contract == "Full Time").ToList();
        }

        viewModel.Jobs = jobs;

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
