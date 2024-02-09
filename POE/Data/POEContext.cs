using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using POE.Model;
using POE.NewFolder;

namespace POE.Data
{
    public class POEContext : DbContext
    {
        public POEContext (DbContextOptions<POEContext> options)
            : base(options)
        {
        }

        public DbSet<POE.Model.User> User { get; set; } = default!;

        public DbSet<POE.Model.Alert>? Alert { get; set; }

        public DbSet<POE.NewFolder.Monetary>? Monetary { get; set; }

        public DbSet<POE.NewFolder.Goods>? Goods { get; set; }
    }
}
