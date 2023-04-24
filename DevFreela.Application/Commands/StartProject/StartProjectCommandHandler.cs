using DevFreela.Infrastructure.Persisntece;
using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjecCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public StartProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(StartProjecCommand request, CancellationToken cancellationToken)
        {
            var project =  _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.StartProject();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;

        }
    }
}
