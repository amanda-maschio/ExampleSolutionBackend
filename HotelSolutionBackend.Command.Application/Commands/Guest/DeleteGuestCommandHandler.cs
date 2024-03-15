using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class DeleteGuestCommandHandler : IRequestHandler<DeleteGuestCommand, Unit>
    {
        private readonly IGuestRepository _guestRepository;

        public DeleteGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Unit> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            var guestType = _guestRepository.GetById(request.Id);
            _guestRepository.Remove(guestType);
            await _guestRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
