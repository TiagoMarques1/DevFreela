using DevFreela.Infrastructure.Persisntece;
using MediatR;

namespace DevFreela.Application.Commands.UpdateProject
{
    public class UpdateProjectCommandHadler : IRequestHandler<UpdateProjectCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;

        public UpdateProjectCommandHadler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.UpdateProject(request.Title, request.Description, request.TotalCost);
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
