using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.RoomType
{
    public class UpdateRoomTypeCommand : IRequest<Unit>
    {
        public int Id;
        public string Name;
        public decimal Value;
        public byte[] Timestamp;
        public UpdateRoomTypeCommand(int id, string name, decimal value, byte[] timestamp)
        {
            Id = id;
            Name = name;
            Value = value;
            Timestamp = timestamp;
        }
    }
}
