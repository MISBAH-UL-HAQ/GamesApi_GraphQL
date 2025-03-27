using Games_APi_GraphQL.Model;
using Microsoft.EntityFrameworkCore;

namespace Games_APi_GraphQL.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<Game> Games { get; set; }
        }
    
}
