using HotelSolutionBackend.Query.Application.Abstractions;
using HotelSolutionBackend.Query.Application.ViewModels;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Query.Application.Queries.User
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<UserViewModel>>
    {
        private readonly IUserAppService _userAppService;

        public GetUserListQueryHandler(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _userAppService.GetAllAsync();
        }
    }
}
