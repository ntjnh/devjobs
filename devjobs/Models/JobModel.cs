namespace devjobs.Models;

public class JobModel
{
    public class JobInfo
    {
        public string? Content { get; set; }
        public List<string>? Items { get; set; }
    }

    public class JobDetails
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Logo { get; set; }
        public string? LogoBackground { get; set; }
        public string? Position { get; set; }
        public string? PostedAt { get; set; }
        public string? Contract { get; set; }
        public string? Location { get; set; }
        public string? Website { get; set; }
        public string? Apply { get; set; }
        public string? Description { get; set; }
        public JobInfo? Requirements { get; set; }
        public JobInfo? Role { get; set; }
    }

    public JobDetails? Job { get; set; }
}