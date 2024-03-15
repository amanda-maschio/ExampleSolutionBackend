using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class DeleteGuestCommand : IRequest<Unit>
    {
        public int Id;

        public DeleteGuestCommand(int id)
        {
            Id = id;
        }
    }
}
