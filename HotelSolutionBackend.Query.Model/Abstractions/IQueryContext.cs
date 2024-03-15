using HotelSolutionBackend.Query.Model.Models;
using System.Linq;

namespace HotelSolutionBackend.Query.Model.Abstractions
{
    public interface IQueryContext
    {
        IQueryable<User> AllUsers { get; }
    }
}
