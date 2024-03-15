using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, Unit>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public UpdateRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<Unit> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var roomType = _roomTypeRepository.GetById(request.Id);

            roomType.SetName(request.Name);
            roomType.SetValue(request.Value);
            _roomTypeRepository.UpdateRowVersionTimestamp(roomType, request.Timestamp);

            await _roomTypeRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
