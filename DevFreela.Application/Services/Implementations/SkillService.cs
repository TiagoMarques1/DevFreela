using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persisntece;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _DevFreelaDbContext;

        public SkillService(DevFreelaDbContext devFreelaDbContext)
        {
            _DevFreelaDbContext = devFreelaDbContext;
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _DevFreelaDbContext.Skills;

            var skillViewModel = skills
                .Select(p => new SkillViewModel(p.Id,p.Description))
                .ToList();

            return skillViewModel;
        }
    }
}
