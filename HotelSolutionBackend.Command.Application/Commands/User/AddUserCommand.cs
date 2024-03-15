using MediatR;
using System;

namespace HotelSolutionBackend.Command.Application.Commands.User
{
    public class AddUserCommand : IRequest<Unit>
    {
        public string Email;
        public string Password;
        public string SessionToken;
        public DateTime Register;
        
        public AddUserCommand(string email, string password, string sessionToken, DateTime register)
        {
            Email = email;
            Password = password;
            SessionToken = sessionToken;
            Register = register;
        }
    }
}
