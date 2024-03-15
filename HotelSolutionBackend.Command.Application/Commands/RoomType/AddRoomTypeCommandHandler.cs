using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class AddRoomTypeCommandHandler : IRequestHandler<AddRoomTypeCommand, Unit>
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public AddRoomTypeCommandHandler(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<Unit> Handle(AddRoomTypeCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.RoomType newRoomType = new Domain.Entities.RoomType(request.Name, request.Value);
            _roomTypeRepository.Add(newRoomType);
            await _roomTypeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
