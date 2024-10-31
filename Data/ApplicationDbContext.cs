using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Task.Data.Entities;

namespace Task.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ImportRequest> ImportRequests { get; set; }
        public DbSet<ImportItem> ImportItems { get; set; }
        public DbSet<Items> Items { get; set; }
        public DbSet<ItemType> ItemType { get; set; }
    }
}
