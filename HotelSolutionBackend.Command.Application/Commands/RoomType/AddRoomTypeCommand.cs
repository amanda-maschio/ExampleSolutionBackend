using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class AddRoomTypeCommand : IRequest<Unit>
    {
        public string Name;
        public decimal Value;

        public AddRoomTypeCommand(string name, decimal value)
        {
            Name = name;
            Value = value;
        }
    }
}
