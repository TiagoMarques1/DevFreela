using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetByIdProject
{
    public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
