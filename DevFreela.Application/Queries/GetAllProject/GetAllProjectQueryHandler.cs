using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProject
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectQueryHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        async Task<List<ProjectViewModel>> IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>.Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetAllAsync();

            var projects = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projects;
        }
    }
}
