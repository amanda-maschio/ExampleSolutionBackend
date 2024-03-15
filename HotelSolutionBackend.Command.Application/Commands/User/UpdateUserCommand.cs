using MediatR;
using System;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public int Id;
        public string Email;
        public string Password;
        public string SessionToken;
        public DateTime Register;

        public UpdateUserCommand(int id, string email, string password, string sessionToken, DateTime register)
        {
            Id = id;
            Email = email;
            Password = password;
            SessionToken = sessionToken;
            Register = register;
        }
    }
}
