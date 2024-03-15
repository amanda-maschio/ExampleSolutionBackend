using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class UpdateGuestCommandHandler : IRequestHandler<UpdateGuestCommand, Unit>
    {
        private readonly IGuestRepository _guestRepository;

        public UpdateGuestCommandHandler(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public async Task<Unit> Handle(UpdateGuestCommand request, CancellationToken cancellationToken)
        {
            var guest = _guestRepository.GetById(request.Id);
            guest.SetName(request.Name);
            guest.SetPhone(request.Phone);
            guest.SetCPF(request.CPF);
            guest.SetEmail(request.Email);
            guest.SetHasPending(request.HasPending);
            if (request.HasPending == false)
            {
                guest.SetAmountPending(0);
            }

            _guestRepository.UpdateRowVersionTimestamp(guest, request.Timestamp);

            await _guestRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
