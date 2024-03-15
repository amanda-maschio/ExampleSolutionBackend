using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Unit>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;

        public UpdateRoomCommandHandler(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository)
        {
            _roomRepository = roomRepository;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<Unit> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = _roomRepository.GetById(request.Id);
            room.SetNumber(request.Number);

            Console.WriteLine(request.RoomTypeId);
            var roomType = _roomTypeRepository.GetById(request.RoomTypeId);
            room.SetRoomType(roomType);

            _roomRepository.UpdateRowVersionTimestamp(room, request.Timestamp);

            await _roomRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
