using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kontakty.Models;

namespace kontakty.Data
{
    public class KontaktyContext : DbContext
    {
        public KontaktyContext (DbContextOptions<KontaktyContext> options)
            : base(options)
        {
        }

        public DbSet<kontakty.Models.Kontakt> Kontakt { get; set; } = default!;
    }
}
