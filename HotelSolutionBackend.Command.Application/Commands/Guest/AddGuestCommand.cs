using MediatR;

namespace HotelSolutionBackend.Command.Application.Commands.Guest
{
    public class AddGuestCommand : IRequest<Unit>
    {
        public string Name;
        public string Phone;
        public string CPF;
        public string Email;
        public bool HasPending;

        public AddGuestCommand(string name, string phone, string cPF, string email, bool hasPending)
        {
            Name = name;
            Phone = phone;
            CPF = cPF;
            Email = email;
            HasPending = hasPending;
        }
    }
}