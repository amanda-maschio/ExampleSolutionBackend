using HotelSolutionBackend.Query.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSolutionBackend.Query.Data.Context
{
    public class HotelSolutionBackendContext : DbContext
    {
        public HotelSolutionBackendContext(DbContextOptions<HotelSolutionBackendContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("user");

            base.OnModelCreating(modelBuilder);
        }
    }
}
