using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persisntece;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
    {
        private readonly IProjectRepository _projectRepository;

        public GetByIdProjectHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {

            var project = await _projectRepository.GetByIdAsync(request.Id);

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


            return projectDetailsViewModel;
        }
    }
}
