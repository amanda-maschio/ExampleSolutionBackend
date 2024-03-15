using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class UpdateGuestCommand : IRequest<Unit>
    {
        public int Id;
        public string Name;
        public string Phone;
        public string CPF;
        public string Email;
        public bool HasPending;
        public byte[] Timestamp;

        public UpdateGuestCommand(int id, string name, string phone, string cPF, string email, bool hasPending, byte[] timestamp)
        {
            Id = id;
            Name = name;
            Phone = phone;
            CPF = cPF;
            Email = email;
            HasPending = hasPending;
            Timestamp = timestamp;
        }
    }
}
