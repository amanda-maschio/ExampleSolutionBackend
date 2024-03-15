using HotelSolutionBackend.Query.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace HotelSolutionBackend.Query.Application.Queries.User
{
    public class GetUserListQuery : IRequest<IEnumerable<UserViewModel>>
    {
    }
}
