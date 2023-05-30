using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persisntece;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.Persistence.Repository
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _dbContext;

        public SkillRepository(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Skill>> GetAllAsync()
        {
            return await _dbContext.Skills.ToListAsync();
        }
    }
}
