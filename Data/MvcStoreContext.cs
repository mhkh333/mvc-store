using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcStore.Models;

namespace MvcStore.Data
{
    public class MvcStoreContext : DbContext
    {
        public MvcStoreContext (DbContextOptions<MvcStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MvcStore.Models.Product> Product { get; set; } = default!;
    }
}
