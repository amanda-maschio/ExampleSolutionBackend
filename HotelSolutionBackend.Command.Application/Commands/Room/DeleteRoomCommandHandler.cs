using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var roomType = _roomRepository.GetById(request.Id);
            _roomRepository.Remove(roomType);
            await _roomRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
