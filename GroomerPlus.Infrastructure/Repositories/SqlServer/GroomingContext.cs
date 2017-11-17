using GroomerPlus.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroomerPlus.Infrastructure.Repositories.SqlServer
{
    public class GroomingContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public GroomingContext(DbContextOptions<GroomingContext> options)
            : base((DbContextOptions) options)
        {
        }
    }
}