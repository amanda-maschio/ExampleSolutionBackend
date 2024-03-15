using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.Id);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }

            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
