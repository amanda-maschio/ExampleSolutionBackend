using HotelSolutionBackend.Query.Application.ViewModels;
using MediatR;

namespace HotelSolutionBackend.Query.Application.Queries.User
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id;

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
