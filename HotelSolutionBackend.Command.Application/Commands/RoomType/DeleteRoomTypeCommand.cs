using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class DeleteRoomTypeCommand : IRequest<Unit>
    {
        public int Id;

        public DeleteRoomTypeCommand(int id)
        {
            Id = id;
        }
    }
}
