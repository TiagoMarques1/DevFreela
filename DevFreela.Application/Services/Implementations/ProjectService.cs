using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persisntece;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public readonly DevFreelaDbContext _DevFreelaDbContext;

        public ProjectService(DevFreelaDbContext devFreelaDbContext)
        {
            _DevFreelaDbContext = devFreelaDbContext;
        }


        public List<ProjectViewModel> GetAll(string query)
        {
            var project = _DevFreelaDbContext.Projects;

            var projects = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            _DevFreelaDbContext.SaveChanges();
            return projects;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _DevFreelaDbContext.Projects
                .Include(x => x.Client)
                .Include(x => x.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishetedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                );

            _DevFreelaDbContext.SaveChanges();

            return projectDetailsViewModel;
        }

    }
}
