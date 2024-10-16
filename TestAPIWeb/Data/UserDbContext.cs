using Microsoft.EntityFrameworkCore;
using TestAPIWeb.Models;

namespace TestAPIWeb.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(GetUsers());
        }

        private static IEnumerable<User> GetUsers()
        {
            var users = new List<User>();
            users.Add(new User { UserId = 1, UserName = "test", Password = "motdepasse" });

            return users;
        }
    }
}
