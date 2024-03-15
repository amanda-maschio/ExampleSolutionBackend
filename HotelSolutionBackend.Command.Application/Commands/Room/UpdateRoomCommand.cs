using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class UpdateRoomCommand : IRequest<Unit>
    {
        public int Id;
        public int Number;
        public int RoomTypeId;
        public byte[] Timestamp;

        public UpdateRoomCommand(int id, int number, int roomTypeId, byte[] timestamp)
        {
            Id = id;
            Number = number;
            RoomTypeId = roomTypeId;
            Timestamp = timestamp;
        }
    }
}
