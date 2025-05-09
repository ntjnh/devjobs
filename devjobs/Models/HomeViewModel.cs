namespace devjobs.Models;

public class HomeViewModel
{
    public List<JobModel.JobDetails>? Vacancies {
        get {
            return [
                new JobModel.JobDetails()
                {
                    Id = 1,
                    Company = "Scoot",
                    LogoBackground = "hsl(36, 87%, 49%)",
                    Position = "Senior Software Engineer",
                    PostedAt = "5h ago",
                    Contract = "Full Time",
                    Location = "United Kingdom"
                },
                new JobModel.JobDetails()
                {
                    Id = 2,
                    Company = "Blogr",
                    LogoBackground = "hsl(12, 79%, 52%)",
                    Position = "Haskell and PureScript Dev",
                    PostedAt = "20h ago",
                    Contract = "Part Time",
                    Location = "United States"
                },
                new JobModel.JobDetails()
                {
                    Id = 3,
                    Company = "Vector",
                    LogoBackground = "hsl(235, 10%, 23%)",
                    Position = "Midlevel Back End Engineer",
                    PostedAt = "1d ago",
                    Contract = "Part Time",
                    Location = "Russia"
                }
            ];
        }
    }
}
