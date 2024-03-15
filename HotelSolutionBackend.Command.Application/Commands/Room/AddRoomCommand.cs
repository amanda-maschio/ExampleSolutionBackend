using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class AddRoomCommand : IRequest<Unit>
    {
        public int Number;
        public int RoomTypeId;
        public AddRoomCommand(int number, int roomTypeId)
        {
            Number = number;
            RoomTypeId = roomTypeId;
        }
    }
}
