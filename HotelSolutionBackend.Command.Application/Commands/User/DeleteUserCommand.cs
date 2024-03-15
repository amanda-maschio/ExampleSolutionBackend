using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public int Id;

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
