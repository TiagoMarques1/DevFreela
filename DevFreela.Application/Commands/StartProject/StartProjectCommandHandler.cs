using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persisntece;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjecCommand, Unit>
    {
        private readonly IProjectRepository _projectRepository;

        public StartProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Unit> Handle(StartProjecCommand request, CancellationToken cancellationToken)
        {
            var project = _projectRepository.GetByIdAsync(request.Id).Result;

            project.StartProject();
            await _projectRepository.StartAsync(project);

            return Unit.Value;

        }
    }
}
