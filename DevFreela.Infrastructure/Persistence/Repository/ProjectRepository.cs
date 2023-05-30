using Azure.Core;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persisntece;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public ProjectRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return _dbContext.Projects
             .Include(x => x.Client)
             .Include(x => x.Freelancer)
             .SingleOrDefaultAsync(p => p.Id == id).Result;

        }

        public async Task AddAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Project project)
        {
            _dbContext.Remove(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(Project project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();
        }

        public async Task FinishAsync(Project project)
        {
             _dbContext.Update(project);
            await _dbContext.SaveChangesAsync();

        }

        public async Task UpdateAsync(Project project)
        {
            _dbContext.Update(project);
            await _dbContext.SaveChangesAsync(); ;
        }

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
