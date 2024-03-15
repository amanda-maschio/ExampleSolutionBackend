using HotelSolutionBackend.Command.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelSolutionBackend.Command.Data.Context
{
    public class HotelSolutionBackendCommandContext : DbContext
    {
        public HotelSolutionBackendCommandContext(DbContextOptions<HotelSolutionBackendCommandContext> options)
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
