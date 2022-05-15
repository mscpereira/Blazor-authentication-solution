using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Reviewer> Reviewers { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
}
