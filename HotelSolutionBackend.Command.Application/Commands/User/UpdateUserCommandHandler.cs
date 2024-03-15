using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetById(request.Id);

            if (user == null)
            {
                throw new ArgumentException("Usuário não encontrado!");
            }

            user.Email = request.Email;
            user.Register = DateTime.Now;

            await _userRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
