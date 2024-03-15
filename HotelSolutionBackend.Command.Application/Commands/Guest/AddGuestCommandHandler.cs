using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class AddGuestCommandHandler : IRequestHandler<AddGuestCommand, Unit>
    {
        private readonly IGuestRepository _guestRepository;

        public AddGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Unit> Handle(AddGuestCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Guest newGuest = new Domain.Entities.Guest(request.Name, request.Phone, request.CPF, request.Email);
            _guestRepository.Add(newGuest);
            await _guestRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
