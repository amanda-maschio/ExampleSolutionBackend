using System;

namespace HotelSolutionBackend.Query.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SessionToken { get; set; }
        public DateTime Register { get; set; }
    }
}
