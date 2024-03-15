using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public AddUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.User newUser = new Domain.Entities.User(request.Email, request.Password, request.SessionToken, DateTime.Now);
            _userRepository.Add(newUser);
            await _userRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
