using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModels;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persisntece;

namespace DevFreela.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DevFreelaDbContext _DevFreelaDbContext;
        public UserService(DevFreelaDbContext devFreelaDbContext)
        {
            _DevFreelaDbContext = devFreelaDbContext;
        }

        public int Create(CreateUserInputModel inputModel)
        {
            var user = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);

            _DevFreelaDbContext.Users.Add(user);
            _DevFreelaDbContext.SaveChanges();

            return user.Id;
        }

        public UserViewModel GetUser(int id)
        {
            var user = _DevFreelaDbContext.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
            {
                return null;
            }

            _DevFreelaDbContext.SaveChanges();

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
