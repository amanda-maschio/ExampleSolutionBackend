using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Room
{
    public class DeleteRoomCommand : IRequest<Unit>
    {
        public int Id;

        public DeleteRoomCommand(int id)
        {
            Id = id;
        }
    }
}
