using HotelSolutionBackend.Query.Data.Context;
using HotelSolutionBackend.Query.Model.Abstractions;
using HotelSolutionBackend.Query.Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HotelSolutionBackend.Query.Data.QueryContext
{
    public class QueryContext : IQueryContext
    {
        private readonly HotelSolutionBackendContext _context;

        public QueryContext(HotelSolutionBackendContext context)
        {
            _context = context;
        }

        public IQueryable<User> AllUsers
        {
            get
            {
                return _context
                .Set<User>();
            }
        }
    }
}
