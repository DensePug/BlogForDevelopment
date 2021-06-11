using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyBlog.API.DataContracts;

namespace MyBlog.API.Helpers
{
    public class BlogContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public BlogContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.GetConnectionString("db"));
    }
}