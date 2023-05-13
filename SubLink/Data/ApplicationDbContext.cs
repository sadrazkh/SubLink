using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubLink.Entities;

namespace SubLink.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CleanIp> CleanIps { get; set; }
        public DbSet<Domain> Domains { get; set; }
        public DbSet<InternetServiceProvider> InternetServiceProviders { get; set; }
        public DbSet<SNI> Snis { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRequestLog> UserRequestLogs { get; set; }
    }
}