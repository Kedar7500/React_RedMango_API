using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RedMango_API.Models;

namespace RedMango_API.Data
{
    public class RedMangoDbContext : IdentityDbContext<ApplicationUser>
    {
        public RedMangoDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        
    }
}
