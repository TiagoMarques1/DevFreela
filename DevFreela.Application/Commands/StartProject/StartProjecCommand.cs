using MediatR;

namespace DevFreela.Application.Commands.StartProject
{
    public class StartProjecCommand : IRequest<Unit>
    {
        public StartProjecCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
