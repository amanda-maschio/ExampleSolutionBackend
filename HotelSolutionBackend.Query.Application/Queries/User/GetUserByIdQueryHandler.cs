using HotelSolutionBackend.Query.Application.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Query.Application.Queries.User
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IMediator _mediator;

        public GetUserByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetUserListQuery());
            var user = users.FirstOrDefault(r => r.Id == request.Id);
            return user;
        }
    }
}
