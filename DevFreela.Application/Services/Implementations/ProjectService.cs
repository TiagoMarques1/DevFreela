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

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, inputModel.TotalCost);

            _DevFreelaDbContext.Projects.Add(project);
            _DevFreelaDbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _DevFreelaDbContext.ProjectComments.Add(comment);
            _DevFreelaDbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            var project = _DevFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.CancelProject();
            _DevFreelaDbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _DevFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.FinishProject();
            _DevFreelaDbContext.SaveChanges();
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

        public void Start(int id)
        {
            var project = _DevFreelaDbContext.Projects.SingleOrDefault(p => p.Id == id);

            project.StartProject();
            _DevFreelaDbContext.SaveChanges();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _DevFreelaDbContext.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.UpdateProject(inputModel.Title, inputModel.Description, inputModel.TotalCost);
            _DevFreelaDbContext.SaveChanges();
        }
    }
}
