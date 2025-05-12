using devjobs.Models;
using devjobs.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace devjobs.Controllers;

public class JobsController : Controller
{
    private readonly JobsService _jobsService;

    public JobsController(JobsService jobsService) => _jobsService = jobsService;

    [Route("Jobs/{keyword?}")]
    [Route("Jobs")]
    public async Task<IActionResult> Index(string keyword)
    {
        var jobs = await _jobsService.GetAsync();

        var viewModel = new JobsViewModel();

        if (!String.IsNullOrEmpty(keyword))
        {
            jobs = jobs.Where(j => j.Position.ToLower().Contains(keyword.ToLower())).ToList();
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
