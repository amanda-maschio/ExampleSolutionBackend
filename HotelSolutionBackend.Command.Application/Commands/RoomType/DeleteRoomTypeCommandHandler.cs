using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommand, Unit>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public DeleteRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<Unit> Handle(DeleteRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = _roomTypeRepository.GetById(request.Id);
            _roomTypeRepository.Remove(roomType);
            await _roomTypeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
