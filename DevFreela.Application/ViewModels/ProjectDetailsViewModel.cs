using System.Reflection.Metadata.Ecma335;

namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal? totalCost, DateTime? startedAt, DateTime? finishetedAt, string clientFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishetedAt = finishetedAt;
            ClientFullName = clientFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal? TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishetedAt { get; private set; }
        public string ClientFullName { get; private set; }
        public string FreelancerFullName { get; private set; }

    }
}
