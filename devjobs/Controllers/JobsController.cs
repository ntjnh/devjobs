using devjobs.Models;
using devjobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace devjobs.Controllers;

public class JobsController : Controller
{
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService) => _jobsService = jobsService;

    [Route("Jobs")]
    [Route("Jobs/Index")]
    public async Task<IActionResult> Index()
    {
        var viewModel = new JobsViewModel
        {
            Jobs = await _jobsService.GetAsync()
        };
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
