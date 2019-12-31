using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class FollowerContext : DbContext
    {
        public FollowerContext(DbContextOptions<FollowerContext> options) : base(options)
        { }

        public DbSet<Follower> Followers {get;set;}
    }
}