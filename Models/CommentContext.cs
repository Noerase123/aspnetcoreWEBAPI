using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RestApi.Models
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        { }

        public DbSet<Comment> Comments {get;set;}
        public ICollection<Post> postsc {get;set;}
    }
}