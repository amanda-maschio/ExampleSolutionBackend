using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;

        public AddRoomCommandHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<Unit> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Room newRoom = new Domain.Entities.Room(request.Number, request.RoomTypeId);
            _roomRepository.Add(newRoom);
            await _roomRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
