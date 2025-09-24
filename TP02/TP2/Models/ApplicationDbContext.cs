using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TP2.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<BL> BLs { get; set; }
        public DbSet<Container> Containers { get; set; }
    }
}
