using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persisntece;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProject
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly DevFreelaDbContext _dbContext;

        public GetAllProjectQueryHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        async Task<List<ProjectViewModel>> IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>.Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects;

            var projects = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            await _dbContext.SaveChangesAsync();
            return projects;
        }
    }
}
