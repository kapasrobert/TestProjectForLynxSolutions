using System.Data.Entity;

namespace TestProjectForLynxSolutions.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}