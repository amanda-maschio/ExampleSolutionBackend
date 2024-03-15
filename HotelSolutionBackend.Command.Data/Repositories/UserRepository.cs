using HotelSolutionBackend.Command.Data.Context;
using HotelSolutionBackend.Command.Domain.Abstractions.Repositories;
using HotelSolutionBackend.Command.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelSolutionBackend.Command.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(HotelSolutionBackendCommandContext db) : base(db)
        {
        }
    }
}
