using Microsoft.EntityFrameworkCore;

namespace RestApi.Models
{
    public class PostContext : DbContext
    {
        public PostContext(DbContextOptions<PostContext> options) : base(options)
        { }

        public DbSet<Post> Posts {get;set;}
    }
}