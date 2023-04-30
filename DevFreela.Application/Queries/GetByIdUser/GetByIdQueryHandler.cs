using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdUser
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdUserQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null;
            }

            return new UserViewModel(user.FullName, user.Email);
        }
    }
}
